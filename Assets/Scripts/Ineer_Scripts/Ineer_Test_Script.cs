/*
 * 这是Ineer用来测试一些全局变量实时值用的，只要挂在相应的角色身上，记得最后要拿掉
 * 按下P键打印信息在控制台
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ineer_Test_Script : MonoBehaviour
{
    public Ineer_Dialog t;
    private bool isbegan = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 按下p键打印信息
        if (Input.GetKeyDown(KeyCode.P))
        {
            // 打印下此时的iFlag值，判断是否符合此时的需求
            Debug.Log(Ineer_Global.GetFlag());
            // 让角色可以移动
            Ineer_Global.SetbMoved(true);
        }

        // 按下p键打印信息
        Debug.Log(Ineer_Global.GetFlag());
        if (Ineer_Global.GetbGem("green") && Ineer_Global.GetbGem("green") && Ineer_Global.GetbGem("yellow") && isbegan == false)
        {
            // 打印下此时的iFlag值，判断是否符合此时的需求
            Debug.Log(Ineer_Global.GetFlag());
            // 让角色可以移动
            Ineer_Global.SetFlag(3);
            t.OpenDialog();
            isbegan = true;
            Ineer_Global.SetbMoved(true);
        }
    }
}
