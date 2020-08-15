using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MeshCutLeft : MonoBehaviour
{
	public Material capMaterial84;
	public GameObject clone;

	void Update()
	{

		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.LTouch))
		{
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{
				if (hit.collider.name.Contains("84Clone"))
				{

					Destroy(hit.collider, 3);
					GameObject victim = hit.collider.gameObject;
					GameObject[] pieces84 = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial84);
					if (!pieces84[1].GetComponent<Rigidbody>()) pieces84[1].AddComponent<Rigidbody>();
					if (!pieces84[0].GetComponent<Rigidbody>()) pieces84[0].AddComponent<Rigidbody>();
					pieces84[1].GetComponent<Rigidbody>().AddForce(Vector3.Cross(-hit.normal, (pieces84[1].transform.position - hit.point).normalized) * (-10), ForceMode.Impulse);// 숫자를 오른 손일때와 왼속일때 반대로 넣으면 됨
					pieces84[0].GetComponent<Rigidbody>().AddForce(Vector3.Cross(-hit.normal, (pieces84[0].transform.position - hit.point).normalized) * (10), ForceMode.Impulse);
					print("p1 : " + pieces84[1].transform.position);
					print("p0 : " + pieces84[0].transform.position);
					Destroy(pieces84[1], 1);
					Destroy(pieces84[0], 1);
				}

			}

		}
	}

	void OnDrawGizmosSelected()
	{

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.11f, transform.position + transform.up * 0.11f + transform.forward * 1.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.11f, transform.position + -transform.up * 0.11f + transform.forward * 1.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.11f);
		Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.11f);

	}

}
