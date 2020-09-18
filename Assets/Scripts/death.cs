using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 角色死亡重加载当前场景
public class death : MonoBehaviour
{
    public GameObject player;
    public PlayerAttribute playerAttribute;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    void Death()
    {
        if (player.transform.position.y < -1)
        {
            //得到当前场景名并重载场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //血量过低时
        else if (playerAttribute.cur_Hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }    
   
}
