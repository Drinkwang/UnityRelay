using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclone : MonoBehaviour
{
    public float speed;
    public int damage;
    public float flyForce;
    public GameObject nowDmgObj;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
    }

    public void CycloneATK()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)//防止重复击飞，每次击飞调用伤害func  CycloneATK() 已注释
    {
        if (collision.tag == "Enemy")
        {
            if (nowDmgObj == collision.gameObject)
            {
                return;
            }
            else
            {
                nowDmgObj = collision.gameObject;
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, flyForce);
               // CycloneATK();
            }
        }
    }
}
