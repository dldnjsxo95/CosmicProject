﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScale : MonoBehaviour
{
	public static NumberScale Instance;
	private void Awake()
	{
		Instance = this;
	}

	public void ComboSize()
	{
		StartCoroutine(ComboScale());
	}

	IEnumerator ComboScale()
	{
		transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

		yield return null;

		transform.localScale = new Vector3(1, 1, 1);
	}
}
