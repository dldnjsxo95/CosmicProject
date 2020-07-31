using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Note84 : MonoBehaviour
{
    // 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
    // 생성되는 위치, 목표 위치, ~~시간
    public GameObject destPos;
    public float delayTime;
    float speed;
    Vector3 dir;

    private void OnEnable()
    {
        destPos = GameObject.Find("Destination84");
        dir = destPos.transform.position - transform.position;
        transform.forward = dir;
        speed = Vector3.Distance(transform.position, destPos.transform.position) / delayTime;
    }


    void Update()
    {

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("DestroyLine"))
        {
            SpawnPoint84.note.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

}