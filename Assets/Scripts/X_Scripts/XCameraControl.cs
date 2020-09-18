//----------------------------------------
//作者：X
//作用：控制相机旋转
//变量：rotationSpeed - 控制相机旋转速度
//----------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XCameraControl : MonoBehaviour
{

    public float rotationSpeed = 5f;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        float axis = -Input.GetAxisRaw("Horizontal");
		
		//当按下A或D时，相机旋转
        //Ineer:这里增加了一个只有允许旋转镜头时才可以执行
		if (axis != 0 && Ineer_Global.GetbRotated())
        {
            this.transform.Rotate(Vector3.up, 5 * Time.deltaTime * axis * rotationSpeed);
        }
    }
}
