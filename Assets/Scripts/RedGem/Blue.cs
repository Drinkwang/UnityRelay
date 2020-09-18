using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 这部分就是捡起green宝石 copy From red
 * 鼠标经过有放大效果（抄群友的）
 * 
 * author：俊壳
 */

public class Blue : MonoBehaviour
{
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = this.transform.localScale;

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
        Ineer_Global.SetbGem("green", true);
        Destroy(this.gameObject);
    }
 }
