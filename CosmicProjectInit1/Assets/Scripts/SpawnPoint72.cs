using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnPoint72 : MonoBehaviour
{
	//60이 0.12초 지속 2초주

	//72가 2초 지속 8초주기

	public GameObject notePrefab;
	public int numberOfNote = 0;
	public static List<GameObject> note = new List<GameObject>();

	public float delayTime = 8;
	public float rematinTime = 2;
	public float makeDelayTime = 0.12f;

	void Awake()
	{
		for (int i = 0; i < numberOfNote; i++)
		{
			note.Add(Instantiate(notePrefab));
			note[i].transform.SetParent(gameObject.transform);
			note[i].SetActive(false);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(GenerateNote());
	}

	IEnumerator GenerateNote()
	{
		
		while (true)
		{
			for (int i = 0; i < rematinTime / makeDelayTime; i++)
			{
				note[0].transform.position = transform.position;
				note[0].SetActive(true);
				note.RemoveAt(0);

				yield return new WaitForSeconds(makeDelayTime);
			}

			yield return new WaitForSeconds(delayTime);
		}
	}

	private void OnDisable()
	{
		StopCoroutine(GenerateNote());
	}

}
