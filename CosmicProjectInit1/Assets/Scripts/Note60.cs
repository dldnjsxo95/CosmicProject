using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note60 : MonoBehaviour
{
	public float speed;

	void Start()
	{

	}

	void Update()
	{
		transform.position -= Vector3.forward * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("Player"))
		{
			SpawnPoint60.note.Add(gameObject);
			gameObject.SetActive(false);
		}
	}

}
