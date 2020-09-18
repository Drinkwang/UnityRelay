using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float x;// 横坐标
    public float y;// 纵坐标
    public float atStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
        atStartPosition = this.gameObject.GetComponent<Transform>().localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Transform>().localPosition.x > atStartPosition)
        {
            this.gameObject.GetComponent<Transform>().localPosition = new Vector3(GameObject.Find("Player").GetComponent<Transform>().localPosition.x, this.gameObject.GetComponent<Transform>().localPosition.y, this.gameObject.GetComponent<Transform>().localPosition.z);
        }
    }
}
