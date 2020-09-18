/*
 * 挂在主角身上的脚本，按下W，S键时，触发对话
 */

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ineer_Dialog : MonoBehaviour
{
    // 对话框
    public GameObject dialog;
    // 移动的地面
    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setFlagOne();
        floor.SetActive(Ineer_Global.GetbMoved());
    }

    void setFlagOne()
    {
        if (Ineer_Global.GetFlag() == 0)
        {
            if (Ineer_Global.Up() || Ineer_Global.Down())
            {
                Ineer_Global.SetFlag(1);
                OpenDialog();
            }
        }
    }

    public void OpenDialog()
    {
        dialog.SetActive(true);
    }
}
