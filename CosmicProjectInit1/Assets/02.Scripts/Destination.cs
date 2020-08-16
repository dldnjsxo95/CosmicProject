using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
	public Transform player;
	public float speed;
	public float MinX;
	public float MaxX;
	public float startDir;
	Vector3 dir;
	Vector3 pos;
	Vector3 origin;
	// Start is called before the first frame update
	void Start()
	{
		dir = Vector3.right * startDir;
	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.tag == "dest60") transform.position = new Vector3(transform.position.x, ReadSignal.YPOS60, transform.position.z);
		if (gameObject.tag == "dest72") transform.position = new Vector3(transform.position.x, ReadSignal.YPOS72, transform.position.z);
		if (gameObject.tag == "dest84") transform.position = new Vector3(transform.position.x, ReadSignal.YPOS84, transform.position.z);


		if (transform.position.x < MinX)
		{
			dir = Vector3.right;
		}

		if (transform.position.x > MaxX)
		{
			dir = Vector3.left;
		}


		transform.position += dir * speed * Time.deltaTime;
		
	}
}
