//----------------------------------------
//作者：X
//作用：从主场景点击门进入房间
//变量：defaultScale - 门组件初始的scale值
//----------------------------------------
// 这里借用了X的部分代码，就是硬COPY，主要用于黄色宝石鼠标的行为，移入，移出，点击。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ineer_Get_Yellow_Gem : MonoBehaviour
{

    Vector3 defaultScale;
    // 对话框
    public GameObject dialog;

    private void Start()
    {
        defaultScale = this.transform.localScale;
        if (Ineer_Global.GetFlag() > 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    //鼠标进入时，宝石放大
    private void OnMouseEnter()
    {
        this.transform.localScale = defaultScale * 1.3f;
    }

    //鼠标离开，宝石大小还原
    private void OnMouseExit()
    {
        this.transform.localScale = defaultScale;
    }

    private void OnMouseUpAsButton()
    {
        this.transform.localScale = defaultScale;
        // 如果iFlag是0，表明没有触发W，S按键，直接点击了宝石，执行dialog_0对话
        // 如果iFlag是1，表明触发了W,S按键，而后才点击的宝石，执行dialog_2对话
        dialog.SetActive(true);
        // 只有在触发dialog_2对话时才能让宝石消失
        if (Ineer_Global.GetFlag() == 2) {
            this.gameObject.SetActive(false);
            // 设置黄色宝石获得
            Ineer_Global.SetbGem("yellow", true);
            // 设置可以看到隐藏地图
            Ineer_Global.SetbShowMap(true);
        }
    }

}
