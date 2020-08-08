using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public enum Music
	{
        NeverBeLikeU,
        DontStartNow,
        Older,
    }
    public static Music music;

    public static Music MUSIC
	{
		get { return music; }
        set { music = value; }
	}

    public GameObject ReadSignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
		{
            music = Music.NeverBeLikeU;
            ReadSignal.SetActive(true);
		}

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            music = Music.DontStartNow;
            ReadSignal.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            music = Music.Older;
            ReadSignal.SetActive(true);
        }

    }
}
