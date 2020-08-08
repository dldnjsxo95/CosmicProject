using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
	public enum Music
	{
		NeverBeLikeU,
		DontStartNow,
		Older,
	}
	public static Music music;
	public GameObject ReadSignal;
	public GameObject SelectUI;

	public Button BntDontStart;
	public Button BntNever;
	public Button BntOlder;


	public static Music MUSIC
	{
		get { return music; }
		set { music = value; }
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		BntDontStart.onClick.AddListener(Dont);
		BntDontStart.onClick.AddListener(Never);
		BntDontStart.onClick.AddListener(Older);

	}

	void Dont()
	{
		music = Music.DontStartNow;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

	void Never()
	{
		music = Music.NeverBeLikeU;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

	void Older()
	{
		music = Music.Older;
		ReadSignal.SetActive(true);
		SelectUI.SetActive(false);
	}

}
