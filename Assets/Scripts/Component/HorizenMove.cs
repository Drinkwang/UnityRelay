using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizenMove : MonoBehaviour
{
    /*
    ///////////不使用刚体重力的2D运动脚本。///////////////////////
    ///////////装载物体要加上刚体组件，可以采用运动学刚体。/////////
    ///////////自带重力效果。////////////////////////////////////
    */
    //这个脚本我只实现了功能没管效率。运行起来可能会拖慢速度。
    //这个脚本有想要的直接复制走就行了，任何2D游戏都可以用上awa。

    public bool isGrivity = true;//是否采用重力

    public int CollitionJudgeAngle = 5;                    //四角方向碰撞检测的范围
    public string[] IgnoreTag;                             //不使用该脚本的对方碰撞器的tag

    public Vector2 ExpectVelocity = new Vector2(0, 0);      //操作速度（期望速度）
    public Vector2 EnvironmentVelocity = new Vector2(0, 0); //环境速度（风力，摩擦）

    [HideInInspector] public bool[] CollitionMode = new bool[8];
    /*
    CollitionMode[i] 用来显示当前碰撞的状态
    为true表示在该方向上有碰撞
    i为方向，0表示正上方，1表示右上方，以此类推顺时针共八个方向碰撞检测。
    */
    [HideInInspector] public bool EmergencyStop = true;//急停？之前写的忘了干什么用的了。顺便一提这个代码是我从之前的工程里扒过来的

    Dictionary<int, int> CollitionDic = new Dictionary<int, int>();
    Rigidbody2D rb = null;
    Transform tf = null;
    [HideInInspector] public Vector2 GrivityAcceleration = new Vector2(0, -0.5F);//重力加速度
    [HideInInspector] public float GrivityVelocity = -30F;                      //重力极限速度

    public bool CollitionJudge(int a, int b)
    {/*
        CollitionMode[i]的简化版，同时检测a-b方向范围内是否有碰撞。
       */
        bool f = false;
        for (int i = a; i <= b; i++)
        {
            if (CollitionMode[i])
            {
                f = true;
                break;
            }
        }
        return f;
    }

    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();

        for (int i = 0; i <= 7; i++) CollitionMode[i] = false;

    }

    void OnCollisionJudge(Collision2D other)
    {
        Vector2 position = new Vector2(tf.position.x, tf.position.y);
        Vector2 csv_vector = other.contacts[0].point - position;
        float csv_angle = Vector2.Angle(csv_vector, Vector2.up);

        int cm = -1;
        if (csv_angle > 135 + CollitionJudgeAngle)
        {
            cm = 4;
        }
        else if (csv_angle > 135 - CollitionJudgeAngle)
        {
            if (csv_vector.x > 0) cm = 3;
            else cm = 5;
        }
        else if (csv_angle > 45 + CollitionJudgeAngle)
        {
            if (csv_vector.x > 0) cm = 2;
            else cm = 6;
        }
        else if (csv_angle > 45 - CollitionJudgeAngle)
        {
            if (csv_vector.x > 0) cm = 1;
            else cm = 7;
        }
        else
        {
            cm = 0;
        }

        if (cm >= 0)
        {
            if (CollitionDic.ContainsKey(other.gameObject.GetInstanceID()))
            {
                CollitionMode[CollitionDic[other.gameObject.GetInstanceID()]] = false;
                CollitionDic[other.gameObject.GetInstanceID()] = cm;
            }
            else
                CollitionDic.Add(other.gameObject.GetInstanceID(), cm);
            CollitionMode[cm] = true;
        }

        if (CollitionMode[4] && EmergencyStop)
        {
            ExpectVelocity.x = 0;
            EmergencyStop = false;
        }

        if (CollitionMode[0] && ExpectVelocity.y > 0) ExpectVelocity.y = 0;
        if (CollitionMode[2] && ExpectVelocity.x > 0) ExpectVelocity.x = 0;
        if (CollitionMode[4] && ExpectVelocity.y < 0) ExpectVelocity.y = 0;
        if (CollitionMode[6] && ExpectVelocity.x < 0) ExpectVelocity.x = 0;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        string Tag = other.gameObject.tag;
        bool canCollide = true;
        for (int i = 0; i < IgnoreTag.Length; i++)
            if (Tag == IgnoreTag[i]) canCollide = false;
        if (canCollide) OnCollisionJudge(other);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        string Tag = other.gameObject.tag;
        bool canCollide = true;
        for (int i = 0; i < IgnoreTag.Length; i++)
            if (Tag == IgnoreTag[i]) canCollide = false;
        if (canCollide) OnCollisionJudge(other);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (CollitionDic.ContainsKey(other.gameObject.GetInstanceID()))
        {
            CollitionMode[CollitionDic[other.gameObject.GetInstanceID()]] = false;
        }
    }

    void FixedUpdate()
    {

        if (isGrivity)
        {
            if (ExpectVelocity.y > GrivityVelocity)
            {
                ExpectVelocity += GrivityAcceleration;
            }
        }

        if (CollitionMode[0] && ExpectVelocity.y > 0) ExpectVelocity.y = 0;
        if (CollitionMode[2] && ExpectVelocity.x > 0) ExpectVelocity.x = 0;
        if (CollitionMode[4] && ExpectVelocity.y < 0) ExpectVelocity.y = 0;
        if (CollitionMode[6] && ExpectVelocity.x < 0) ExpectVelocity.x = 0;

        rb.velocity = ExpectVelocity + EnvironmentVelocity;//**************
    }

    void Update()
    {

    }
}
