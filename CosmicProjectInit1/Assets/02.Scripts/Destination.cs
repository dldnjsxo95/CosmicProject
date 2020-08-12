using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
	public Transform player;
	public float forward;
	public float down;

	public float speed;
	public float MinX;
	public float MaxX;
	public float startDir;

	Vector3 dir;
	// Start is called before the first frame update
	void Start()
	{
		dir = Vector3.right * startDir;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < MinX)
		{
			dir = Vector3.right;
		}

		if (transform.position.x > MaxX)
		{
			dir = Vector3.left;
		}

		transform.position += dir.normalized * speed * Time.deltaTime;
	}
}
