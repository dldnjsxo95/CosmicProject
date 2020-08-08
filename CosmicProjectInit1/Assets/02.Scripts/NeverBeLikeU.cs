using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverBeLikeU : MonoBehaviour
{
    public static NeverBeLikeU Instance;
    private void Awake()
    {
        Instance = this;
    }

    public AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
    }

    void Update()
    {

    }
}
