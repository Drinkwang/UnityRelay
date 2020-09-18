//----------------------------------------
//作者：X
//作用：从主场景点击门进入房间
//变量：defaultScale - 门组件初始的scale值
//----------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XDoorToHome : MonoBehaviour
{

    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = this.transform.localScale;
    }

    //鼠标进入时，门放大
    private void OnMouseEnter()
    {
        this.transform.localScale = defaultScale * 1.1f;
    }

    //鼠标离开，门大小还原
    private void OnMouseExit()
    {
        this.transform.localScale = defaultScale;
    }

    private void OnMouseUpAsButton()
    {
        this.transform.localScale = defaultScale;
        //转入房间(Home)场景
        SceneManager.LoadScene(1);
    }

}
