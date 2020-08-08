using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
	public static MusicManager Instance;
	private void Awake()
	{
		if (Instance != null)
		{
			Instance = this;
		}
	}

	public enum Music
	{
		NeverBeLikeU,
		DontStartNow,
		Older,
	}
	public static Music music;
	public GameObject ReadSignal;
	public GameObject SelectUI;

	public static Music MUSIC
	{
		get { return music; }
		set { music = value; }
	}

	public void Dont()
	{
		music = Music.DontStartNow;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

	public void Never()
	{
		music = Music.NeverBeLikeU;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

	public void Older()
	{
		music = Music.Older;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

}
