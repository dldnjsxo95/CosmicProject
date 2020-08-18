using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Note60 : MonoBehaviour
{
	// 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
	// 생성되는 위치, 목표 위치, ~~시간
	GameObject destPos; // 도착 위치
	public float delayTime; // 도착지점 까지 걸리는 시간
	float speed; // 박스의 움직이는 속도

	Vector3 dir; // 움직이는 방향



	public GameObject particle;


	private void OnEnable()
	{
		destPos = GameObject.Find("Destination60"); // 목적지를 찾는다.
		dir = destPos.transform.position - transform.position; // 방향을 도착 지점으로 설정하고
		transform.forward = dir; // 도착지점으로 바라보게 한다.
		speed = Vector3.Distance(transform.position, destPos.transform.position) / delayTime; // 박스의 움직이는 속도를 [속도 = 거리/시간] 공식을 이용하여 계산하고 대입한다. 
	}


	void Update()
	{
		transform.position += dir.normalized * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		// 만약 오브젝트가 DestroyLine에 부딪히면 
		if (other.gameObject.name.Contains("DestroyLine"))
		{
			SpawnPoint60.note.Add(gameObject); // 해당 노트를 추가 해준다
			gameObject.SetActive(false);// 해당 노트의 상태를 false로 만들어준다.
			UIManager.Instance.combo = 0;
		}

		//if (other.gameObject.tag == "Player" && Player.COLOR == Player.State.Blue)
		//{
		//	UIManager.Instance.combo += 1;
		//	SpawnPoint60.note.Add(gameObject);
		//	GameObject par = Instantiate(particle);
		//	par.transform.position = transform.position;
		//	par.transform.forward = -dir;
		//	transform.position = ResponPos.transform.position;
		//	gameObject.SetActive(false);


		//	// SideBar 색 바꾸기
		//	GameObject sideBarL = GameObject.Find("SideBarL_1");
		//	sideBarL.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;
		//	GameObject sideBarR = GameObject.Find("SideBarR_1");
		//	sideBarR.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;
		//	GameObject RParent = GameObject.Find("SideBarR");
		//	GameObject LParent = GameObject.Find("SideBarL");

		//	for (int i = 0; i < RParent.transform.childCount; i++)
		//	{
		//		if (RParent.transform.GetChild(i).GetComponent<SideBar1>())
		//			RParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
		//		if (RParent.transform.GetChild(i).GetComponent<SideBar2>())
		//			RParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
		//		if (LParent.transform.GetChild(i).GetComponent<SideBar1>())
		//			LParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
		//		if (LParent.transform.GetChild(i).GetComponent<SideBar2>())
		//			LParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
		//	}

		//}


		// VR에서 작동
		if (other.gameObject.tag == "LeftHand" && LeftHand.COLOR == LeftHand.State.Blue)
		{
			
			UIManager.Instance.combo += 1;
			SpawnPoint60.note.Add(gameObject);
			GameObject par = Instantiate(particle);
			par.transform.position = transform.position;
			par.transform.forward = -dir;
			gameObject.SetActive(false);


			// SideBar 색 바꾸기
			GameObject sideBarL = GameObject.Find("SideBarL_1");
			sideBarL.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;
			GameObject sideBarR = GameObject.Find("SideBarR_1");
			sideBarR.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;
			GameObject RParent = GameObject.Find("SideBarR");
			GameObject LParent = GameObject.Find("SideBarL");

			for (int i = 0; i < RParent.transform.childCount; i++)
			{
				if (RParent.transform.GetChild(i).GetComponent<SideBar1>())
					RParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
				if (RParent.transform.GetChild(i).GetComponent<SideBar2>())
					RParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
				if (LParent.transform.GetChild(i).GetComponent<SideBar1>())
					LParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
				if (LParent.transform.GetChild(i).GetComponent<SideBar2>())
					LParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
			}



		}

	}









}