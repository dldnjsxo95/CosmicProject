﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note72 : MonoBehaviour
{
    public float speed;
    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("DestroyLine"))
		{
			SpawnPoint72.note.Add(gameObject);
			gameObject.SetActive(false);
		}

	}

}
