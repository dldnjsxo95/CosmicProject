using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class RightHand : MonoBehaviour
{
	//public float speed = 5; //속도
	Renderer playerColor; //렌더러속성
	public static bool isRed = false; //색 판별
	public GameObject blade; //블레이드
	public GameObject bladeShape; //블레이드 가시성을 위한 형체
	float colorValue;

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
}
