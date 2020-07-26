using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint60 : MonoBehaviour
{
	//60이 0.12초 지속 2초주

	//72가 2초 지속 8초주기

	// 시작하면 게임 오브젝트 생성 

	// 2초에 하나씩 생성 

	public GameObject notePrefab;
	public GameObject noteParent;
	public int numberOfNote = 0;
	public static List<GameObject> note = new List<GameObject>();

	float curTime;
	public float delayTime = 2; 

	void Awake()
	{
		for(int i = 0; i< numberOfNote; i++ )
		{
			note.Add(Instantiate(notePrefab));
			note[i].transform.SetParent(noteParent.transform);
			note[i].SetActive(false);
		}
	}

	private void OnEnable()
	{
		curTime = 0;
		note[0].transform.position = transform.position;
		note[0].SetActive(true);
		note.RemoveAt(0);

	}


	private void Update()
	{
		curTime += Time.deltaTime;

		if(curTime > delayTime )
		{
			curTime = 0;
			note[0].transform.position = transform.position;
			note[0].SetActive(true);
			note.RemoveAt(0);
		}
	}

}
