using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Note84 : MonoBehaviour
{
	// 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
	// 생성되는 위치, 목표 위치, ~~시간
	public GameObject clonePref;
	GameObject destPos;
	public float delayTime;
	float speed;
	Vector3 dir;

	Rigidbody rb;

	private void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		destPos = GameObject.Find("Destination84");
		dir = destPos.transform.position - transform.position;
		transform.forward = dir;
		speed = Vector3.Distance(transform.position, destPos.transform.position) / delayTime;

	}


	void Update()
	{
		rb.velocity = dir.normalized * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("DestroyLine"))
		{
			SpawnPoint84.note.Add(gameObject);
			gameObject.SetActive(false);
            UIManager.Instance.combo = 0;
        }

		if (other.gameObject.name.Contains("(BladeTempShape)"))
		{
            UIManager.Instance.combo += 1;
			WordScale.Instance.ComboSize();
			NumberScale.Instance.ComboSize();

            UIManager.Instance.score += bonus;

            GameObject clone = Instantiate(clonePref);
			clone.transform.position = transform.position;
			clone.transform.forward = transform.forward;
			Destroy(clone, 1.2f);
			SpawnPoint84.note.Add(gameObject);
			gameObject.SetActive(false);
		}

	}

}