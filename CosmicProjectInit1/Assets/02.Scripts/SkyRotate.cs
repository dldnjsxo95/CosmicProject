using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotate : MonoBehaviour
{
	public float RotateSpeed = 1.2f;

	// Update is called once per frame
	void Update()
	{
		RenderSettings.skybox.SetFloat("_Rotation", RotateSpeed * Time.deltaTime);
	}
}
