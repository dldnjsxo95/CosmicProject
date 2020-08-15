using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class LeftHand : MonoBehaviour
{
	//public float speed = 5; //속도
	Renderer playerColor; //렌더러속성
	public GameObject blade; //블레이드
	public GameObject bladeShape; //블레이드 가시성을 위한 형체
	public float vibrationPower;
	public float vibrationTime;

	LineRenderer layser;
	GameObject currentObject;
	public float raycastDistance = 100f;


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
		color = State.Blue;
		COLOR = State.Blue;
		playerColor = gameObject.GetComponent<Renderer>();
		blade.SetActive(false);
		bladeShape.SetActive(false);

		layser = gameObject.AddComponent<LineRenderer>();

		Material material = Resources.Load("60") as Material;
		layser.material = material;
		layser.positionCount = 2;
		layser.startWidth = 0.01f;
		layser.endWidth = 0.01f;

	}

	void Update()
	{
		if(UIManager.Instance.curUIState == UIManager.UIState.onPlay)
		{
			layser.SetPosition(0, transform.position);
			layser.SetPosition(1, transform.position);
			Blade();
		}
		else
		{
			Selectmenu();
		}

	}

	void Blade()
	{
		//S키를 누르는 동안에만 블레이드 활성화
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
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

	void Selectmenu()
	{
		layser.SetPosition(0, transform.position);

		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hitInfo;

		if (Physics.Raycast(ray, out hitInfo))
		{
			layser.SetPosition(1, hitInfo.point);

			if (hitInfo.collider.gameObject.CompareTag("Button"))
			{
				print("button collider");
				if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
				{
					hitInfo.collider.gameObject.GetComponent<Button>().onClick.Invoke();
				}
				else
				{
					hitInfo.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
					currentObject = hitInfo.collider.gameObject;
				}
			}
		}
		else
		{
			layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));


			if (currentObject != null)
			{
				currentObject.GetComponent<Button>().OnPointerExit(null);
				currentObject = null;
			}

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("60") || other.name.Contains("84"))
		{
			StartCoroutine(Vibration());
		}

		

	}

	IEnumerator Vibration()
	{

		OVRInput.SetControllerVibration(vibrationPower, vibrationPower, OVRInput.Controller.LTouch);

		yield return new WaitForSeconds(vibrationTime);

		OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

	}
}
