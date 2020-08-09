using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBar1 : MonoBehaviour
{
	float upMax = -5.9f;
	float downMax = -9.9f;
	float currentPositionX;
	float currentPositionY;
	float currentPositionZ;
	float direction = 3.0f; //이동속도+방향

	// Start is called before the first frame update
	void Start()
	{
		currentPositionX = transform.localPosition.x;
		currentPositionY = transform.localPosition.y;
		currentPositionZ = transform.localPosition.z;
		//Invoke("Update", 3f);
	}

	// Update is called once per frame
	void Update()
	{
		GameObject parent = transform.parent.gameObject;
		GetComponent<MeshRenderer>().material = parent.transform.GetChild(0).GetComponent<MeshRenderer>().material;

		currentPositionY += Time.deltaTime * direction;

		if (currentPositionY >= upMax)
		{
			direction *= -1;
			currentPositionY = upMax;
		}
		else if (currentPositionY <= downMax)
		{
			direction *= -1;
			currentPositionY = downMax;
		}
		transform.localPosition = new Vector3(currentPositionX, currentPositionY, currentPositionZ);



	}

	bool isCoroutine = true;

	public void StartCoroutin()
	{
		StartCoroutine(SlideShake());
	}

	IEnumerator SlideShake()
	{
		if (isCoroutine)
		{
			isCoroutine = !isCoroutine;

			for (int i = 0; i < 4; i++)
			{
				currentPositionZ += 1f;

				yield return null;

				currentPositionZ -= 1f;

				yield return null;

			}
		}

		isCoroutine = !isCoroutine;
	}


	#region TaeGyu's Code
	//Vector3 originPosition;
	//Quaternion originRotation;
	//float shake_decay = 1;
	//float shake_intensity = 1;
	//private float temp_shake_intensity = 0;


	//float direction2 = 30;
	//float leftMax = 3;
	//float rightMax = 3;
	//float amount = 10;
	//public void SideBar()
	//{
	//    // SideBar 색 바꾸기
	//    GameObject sideBarL = GameObject.Find("SideBarL_1");
	//    sideBarL.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;
	//    GameObject sideBarR = GameObject.Find("SideBarR_1");
	//    sideBarR.GetComponent<MeshRenderer>().material = Resources.Load("60") as Material;

	//    GameObject sideBar = GameObject.Find("SideBar");

	//    // SideBar 움찔거리게

	//    //sideBar.transform.position = new Vector3(sideBarPositionX + Mathf.Sin(Time.time * amount) * amount, sideBarPositionY, sideBarPositionZ);
	//    //if (temp_shake_intensity > 0)
	//    //{
	//    //    transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
	//    //    transform.rotation = new Quaternion(
	//    //        originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
	//    //        originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
	//    //        originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
	//    //        originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
	//    //    temp_shake_intensity -= shake_decay;
	//    //}



	//    if (currentPositionX >= leftMax)
	//    {
	//        direction2 *= 1;
	//        currentPositionX = leftMax;
	//    }
	//    else if (currentPositionX <= rightMax)
	//    {
	//        direction2 *= -1;
	//        currentPositionX = rightMax;
	//    }

	//    sideBar.transform.localPosition = new Vector3(currentPositionX, currentPositionY, currentPositionZ);
	//}
	#endregion
}
