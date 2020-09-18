using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform camUI;//声明一个摄像头来跟踪小人的头部
    public Rigidbody2D rb;
    public Transform tf;
    public HorizenMove hzm;

    bool isDum;

    [HideInInspector] public Vector2 velocity;
    public float speed;
    public float jumpSpeed;

    void Move()
    {
        if (PlayerAttribute._Instance.cur_Status != Status.Irremovability)
        {
            hzm.ExpectVelocity.x = 0;
            if (FUNCTION.Left()) hzm.ExpectVelocity.x = -PlayerAttribute._Instance.cur_Spd;
            if (FUNCTION.Right()) hzm.ExpectVelocity.x = PlayerAttribute._Instance.cur_Spd;
        }
    }
    void Jump()
    {
        if (FUNCTION.Jump())
        {
            if (PlayerAttribute._Instance.cur_Status != Status.Irremovability)
            {
                if (hzm.CollitionMode[4]) hzm.ExpectVelocity.y = PlayerAttribute._Instance.cur_JSpd;
                AudioClip t = Resources.Load<AudioClip>("jump");
                Audomanage.instance.OnPlay(1,t,this.transform);
            }
        }
    }
    void Dum()//蹲下的操作（划掉）这是缩小
    {
        // if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftCommand))
        if (FUNCTION.Dum())
        {
            float tf_size = isDum ? 1 : 0.5f;
            tf.transform.localScale = new Vector3(tf_size, tf_size, tf_size);
            isDum = !isDum;
        }
    }
    void CamUI()//摄像头跟随小人移动
    {
        camUI.position = tf.position + new Vector3(0, 0, -1);
    }
    void Update()
    {
        Move();
        Jump();
        Dum();
        CamUI();
    }
}
