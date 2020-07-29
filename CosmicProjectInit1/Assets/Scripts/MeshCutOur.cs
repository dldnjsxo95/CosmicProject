using UnityEngine;
using System.Collections;

public class MeshCutOur : MonoBehaviour
{

	public Material capMaterial60;
	public Material capMaterial72;

	// Use this for initialization
	void Start()
	{


	}

	void Update()
	{

		if (Input.GetKey(KeyCode.S))
		{
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{

				GameObject victim = hit.collider.gameObject;

				GameObject[] pieces60 = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial60);
				GameObject[] pieces72 = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial72);

				if (!pieces60[1].GetComponent<Rigidbody>())  pieces60[1].AddComponent<Rigidbody>();
				if (!pieces60[0].GetComponent<Rigidbody>())  pieces60[0].AddComponent<Rigidbody>();
				if (!pieces72[1].GetComponent<Rigidbody>())  pieces72[1].AddComponent<Rigidbody>();
				if (!pieces72[0].GetComponent<Rigidbody>())  pieces72[0].AddComponent<Rigidbody>();

				pieces60[1].GetComponent<Rigidbody>().AddForce(Vector3.right * 5, ForceMode.Impulse);
				pieces60[0].GetComponent<Rigidbody>().AddForce(Vector3.right * (-5), ForceMode.Impulse);
				pieces72[1].GetComponent<Rigidbody>().AddForce(Vector3.right * 5, ForceMode.Impulse);
				pieces72[0].GetComponent<Rigidbody>().AddForce(Vector3.right * (-5), ForceMode.Impulse);

				Destroy(pieces60[1], 1);
				Destroy(pieces60[0], 1);
				Destroy(pieces72[1], 1);
				Destroy(pieces72[0], 1);
			}

		}
	}

	void OnDrawGizmosSelected()
	{

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);

	}

}
