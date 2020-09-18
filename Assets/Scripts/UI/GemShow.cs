using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 显示宝石的UI
 * 
 * author：竹杖芒鞋
 */


public class GemShow : MonoBehaviour
{
    public GameObject yellow, red, green;
    private void Update()
    {
        if (Ineer_Global.GetbGem("red"))
        {
            red.SetActive(true);
        }
        else
        {
            red.SetActive(false);
        }

        if (Ineer_Global.GetbGem("yellow"))
        {
            yellow.SetActive(true);
        }
        else
        {
            yellow.SetActive(false);
        }

        if (Ineer_Global.GetbGem("green"))
        {
            green.SetActive(true);
        }
        else
        {
            green.SetActive(false);
        }
    }
}
