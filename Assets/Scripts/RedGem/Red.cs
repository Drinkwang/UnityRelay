using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 这部分就是捡起红色宝石
 * 鼠标经过有放大效果（抄群友的）
 * 
 * author：竹杖芒鞋
 */

public class Red : MonoBehaviour
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
        Ineer_Global.SetbGem("red", true);
        Destroy(this.gameObject);
    }
 }
