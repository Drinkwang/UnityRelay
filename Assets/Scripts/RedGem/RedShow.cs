using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 这部分就是碰到那个我也不知道叫啥的东西，会出现红色宝石，并且需要先捡到黄色宝石
 * 
 * author：竹杖芒鞋
 */
public class RedShow : MonoBehaviour
{
    public GameObject redGem;
    private void Start()
    {
        redGem.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Ineer_Global.GetbGem("yellow"))
        {
            redGem.SetActive(true);
        }
    }
}
