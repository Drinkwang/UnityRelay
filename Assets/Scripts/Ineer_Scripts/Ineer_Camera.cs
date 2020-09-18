/*
 * 相机跟随角色移动，但发现抖动有点严重，后续大佬如果能改进则改，不想要就把这个脚本去掉吧。
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ineer_Camera : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position - offset;
    }
}
