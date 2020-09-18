using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 炮塔,发射子弹
 */
public class Turret : MonoBehaviour
{
    /**
     * 速度和方向
     */
    public Vector3 speed = new Vector3(-5, 0, 0);

    /**
     * 子弹
     */
    public GameObject bulletGo;

    /**
     * 发射间隔
     */
    public float interval = 3;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            var go = Instantiate(bulletGo);
            var bullet = go.GetComponent<Bullet>() ?? go.AddComponent<Bullet>();
            bullet.Init(speed);
            AudioClip t = Resources.Load<AudioClip>("biu");
            Audomanage.instance.OnPlay(1, t, this.transform);
            go.transform.position = transform.position + new Vector3(-0.4f, 0, 0);
            yield return new WaitForSeconds(interval);
        }
    }
}