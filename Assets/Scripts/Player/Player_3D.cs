
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_3D : MonoBehaviour
{
	public NavMeshAgent agent;

	//光标生成器
	public CreateCursor cc;

	//目标位置
	public Vector3 point;

	void Start()
	{
		agent.updateRotation = false;
	}

	void Update()
	{
		PlayerMove();
	}

	
	// 使用了navmesh的点击移动方法
	public void PlayerMove()
	{
		//鼠标点击场景设置目标点
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			//如果点击目标点为地板
			if (Physics.Raycast(ray, out hit))
			{
				if (!hit.collider.tag.Equals("Floor"))
				{
					//Debug.Log("点击处无法移动");
					return;
				}
				point = hit.point;			
				agent.SetDestination(point);
			}
		}

		//距离目标位置的距离小于0.5后，隐藏光标
		//之前的写法一直有bug，才用的这种影响效率的办法，还望大佬指点
		if (agent.remainingDistance < 0.5f)
		{
			cc.HideCursor();
		}
		else
		{
			cc.ShowCursor(point);
		}

	}
}
