//----------------------------------------
//作者：X
//作用：返回主场景按钮
//变量：N
//----------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XReturnButtonUI : MonoBehaviour
{

    private void Start()
    {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnReturnBtnClick);
    }

    //按钮点击事件，返回主场景
    private void OnReturnBtnClick()
    {
        //返回主场景
        SceneManager.LoadScene(0);
    }


}
