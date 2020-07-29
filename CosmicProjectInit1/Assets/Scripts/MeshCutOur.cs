using UnityEngine;
using System.Collections;

public class MeshCutOur : MonoBehaviour
{

	public Material capMaterial;

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

				GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

				if (!pieces[1].GetComponent<Rigidbody>())
					pieces[1].AddComponent<Rigidbody>();
				if (!pieces[0].GetComponent<Rigidbody>())
					pieces[0].AddComponent<Rigidbody>();

				pieces[1].GetComponent<Rigidbody>().AddForce(Vector3.right*5, ForceMode.Impulse);
				pieces[0].GetComponent<Rigidbody>().AddForce(Vector3.right * (-5), ForceMode.Impulse);

				Destroy(pieces[1], 2);
				Destroy(pieces[0], 2);
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
