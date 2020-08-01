using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Player : MonoBehaviour
{
	//public float speed = 5; //속도
	Renderer playerColor; //렌더러속성
	public static bool isRed = true; //색 판별
	public GameObject blade; //블레이드
	public GameObject bladeShape; //블레이드 가시성을 위한 형체
	float colorValue;
	// 미사일 발사하고싶다
	// 필요요소 - rb, 미사일팩토리, 발사하는곳
	//public GameObject missileFactory;
	//public Transform firePosition;

	public enum State
	{
		Red,
		Blue,
	}
	public static State color;

	public static State COLOR
	{
		get { return color; }
		set { color = value; }
	}



	void Start()
	{
		color = State.Red;
		playerColor = gameObject.GetComponent<Renderer>();
		blade.SetActive(false);
		bladeShape.SetActive(false);
	}

	void Update()
	{
		//A키를 누르면 플레이어 색 변경
		if (Input.GetKeyDown(KeyCode.A))
		{
			ChangeColor();
		}

		//S키를 누르는 동안에만 블레이드 활성화
		if (Input.GetKey(KeyCode.S))
		{
			blade.SetActive(true);
			bladeShape.SetActive(true);
		}
		else
		{
			blade.SetActive(false);
			bladeShape.SetActive(false);
		}

	}

	//마우스 드래그에 따라 움직이는 플레이어 객체
	private void OnMouseDrag()
	{
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.6f);
		this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
	}

	//색 바꿔주기
	private void ChangeColor()
	{
		if (playerColor.material.color != Color.red)
		{
			playerColor.material.color = Color.red;
			COLOR = State.Red;
		}
		else
		{
			playerColor.material.color = Color.blue;
			COLOR = State.Blue;
		}
	}

	//void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.tag == "RedNotes"  )
	//	{
	//		if (isRed)
	//		{
	//			SpawnPoint72.note.Add(other.gameObject);
	//			other.gameObject.SetActive(false);
	//		}
	//	}

	//	if (other.gameObject.tag == "BlueNotes" )
	//	{
	//		if (!isRed)
	//		{
	//			SpawnPoint60.note.Add(other.gameObject);
	//			other.gameObject.SetActive(false);
	//		}
	//	}
	//}
}
