using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Alive,//存活
    Dead,//死亡
    SpdslowDown,//移动减缓（意义不明暂时）
    Irremovability,//无法移动
    UnStopped,//不可阻挡（霸体状态）
    Invincible//无敌
}
public class PlayerAttribute : MonoBehaviour
{
    public static PlayerAttribute _Instance;

    private void Awake()
    {
        _Instance = this;
    }
    public Status cur_Status = Status.Alive;//当前状态
    public int max_Hp = 5;//血量上限
    public int max_Mp = 5;//法力上限
    public int max_Atk = 5;//攻击上限（允许当前攻击超过）
    public int max_Spd = 5;//速度上限（允许当前速度超过）
    public int max_JSpd = 7;//跳跃速度上限（允许当前速度超过）

    public int cur_Hp;//当前血量
    public int cur_Mp;//当前法力
    public int cur_Atk;//当前攻击
    public int cur_Spd;//当前速度
    public int cur_JSpd;//当前跳跃速度

    public float bloodPercent;//百分比生命值，血条用
    public float MagicPercent;//百分比法力值，蓝条用

    //Ineer:绑定一个隐藏地图
    public GameObject hideMap;

    private void Start()
    {
        Init(); 
    }

    private void Update()
    {
        bloodPercent = cur_Hp / max_Hp;
        MagicPercent = cur_Mp / max_Mp;
        //Ineer:设置隐藏地图
        SetHideMap();
    }

    //初始化
    public void Init()
    {
        cur_Hp = max_Hp;
        cur_Mp = max_Mp;
        cur_Atk = max_Atk;
        cur_Spd = max_Spd;
        cur_JSpd = max_JSpd;
    }
    //死亡时的一些处理
    public void Dead()
    {
        Debug.Log("你死了");
    }

    #region 一些方法
    //造成伤害
    public void ReceiveDamage(int value)
    {
        if (cur_Status != Status.Dead)
        {
            cur_Hp -= value;
            if (cur_Hp <= 0)
            {
                cur_Status = Status.Dead;
                Dead();
            }
        }
    }
    //生命恢复
    public void RecoverHp(int value)
    {
        if (cur_Status != Status.Dead)
        {
            cur_Hp += value;
            if (cur_Hp >= max_Hp)
            {
                cur_Hp = max_Hp;
            }
        }
    }
    //状态改变
    public void ChangeStatus(Status _status)
    {
        if (cur_Status != Status.Dead)
        {
            cur_Status = _status;
        }
    }
    //TODO



    #endregion


    // 获得角色状态
    public Status GetStatus()
    {
        return cur_Status;
    }


    // 显示隐藏地图
    public void SetHideMap()
    {
        hideMap.SetActive(Ineer_Global.GetbShowMap());
    }
}
