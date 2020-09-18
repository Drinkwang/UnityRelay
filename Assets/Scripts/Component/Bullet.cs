using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /**
     * 速度和方向
     */
    public Vector3 speed = new Vector3(5, 0, 0);

    /**
     * 攻击力
     */
    public int damage = 5;

    /**
     * 速度方向和攻击力
     */
    public void Init(Vector3 vec, int dmg = 5)
    {
        speed = vec;
        damage = dmg;
        //TODO:设置方向
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAttribute>().ReceiveDamage(damage);
            Destroy(gameObject);
            //TODO:爆炸效果
        }
    }
}