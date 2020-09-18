/*
 * 全局变量 iFlag记录旗帜
 * 这里添加了W，S按键，获取和设置iFlag
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ineer_Global : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static int iFlag; // 触发旗帜，0代表无触发，1代表触发第一个机关, 2代表拿到黄色宝石
    static bool bMoved = false; // 是否可以移动
    static bool bRotated = true; // 是否可以旋转镜头

    // 是否拥有宝石
    static bool bRedGem = false;
    static bool bGreenGem = false;
    static bool bYellowGem = false;

    // 是否显示隐藏的地图
    static bool bShowMap = false;

    // 增加W,S按键
    public static bool Up()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool Down()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int GetFlag()
    {
        return iFlag;
    }

    public static int SetFlag(int num)
    {
        iFlag = num;
        return iFlag;
    }

    public static bool GetbMoved()
    {
        return bMoved;
    }

    public static bool SetbMoved(bool b)
    {
        bMoved = b;
        return bMoved;
    }

    public static bool GetbRotated()
    {
        return bRotated;
    }

    public static bool SetbRotated(bool b)
    {
        bRotated = b;
        return bRotated;
    }

    public static bool GetbGem(string gem)
    {
        bool b = false;
        switch(gem)
        {
            case "red":
                b = bRedGem;
                break;
            case "green":
                b = bGreenGem;
                break;
            case "yellow":
                b = bYellowGem;
                break;
        }
        return b;
    }

    public static bool SetbGem(string gem, bool b)
    {
        switch (gem)
        {
            case "red":
                bRedGem = b;
                break;
            case "green":
                bGreenGem = b;
                break;
            case "yellow":
                bYellowGem = b;
                break;
        }
        return b;
    }

    public static bool GetbShowMap()
    {
        return bShowMap;
    }

    public static bool SetbShowMap(bool b)
    {
        bShowMap = b;
        return bShowMap;
    }
}
