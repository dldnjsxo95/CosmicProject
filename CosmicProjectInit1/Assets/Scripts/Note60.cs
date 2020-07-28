using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note60 : MonoBehaviour
{
	// 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
	// 생성되는 위치, 목표 위치, ~~시간
	public GameObject instancePos;
	public GameObject destPos;
	public float barTime;

	public float speed;

	void Start()
	{
		//barTime = BPM * 4;
		//destPos = GameObject.Find("Dest");
	}

	void Update()
	{

		transform.position -= Vector3.forward * speed * Time.deltaTime;


		// 생성된 위치부터 목표 위치까지 barTime동안 가고싶다.
		//transform.position = Vector3.Lerp(instancePos.transform.position, destPos.transform.position, barTime * Time.deltaTime /1000);

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("Standardline"))
		{
			SpawnPoint60.note.Add(gameObject);
			gameObject.SetActive(false);
		}
	}

}
