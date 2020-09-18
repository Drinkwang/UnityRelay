using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCursor : MonoBehaviour
{
	//光标预制体
	public GameObject PrefabCursor;

	//实际生成预制体
	public GameObject gameCursor;


	private void Start()
	{
		gameCursor = Instantiate(PrefabCursor);
	}

	public void ShowCursor(Vector3 point)
	{
		gameCursor.SetActive(true);
		gameCursor.transform.position = point;

	}

	public void HideCursor()
	{
		gameCursor.SetActive(false);
	}
}
