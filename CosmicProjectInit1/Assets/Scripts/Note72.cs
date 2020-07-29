using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Note72 : MonoBehaviour
{
    // 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
    // 생성되는 위치, 목표 위치, ~~시간
    public GameObject destPos;
    public float delayTime;
    float speed;
    Vector3 dir;

    private void OnEnable()
    {
        destPos = GameObject.Find("Destination72");
        dir = destPos.transform.position - transform.position;
        transform.forward = dir;
        speed = Vector3.Distance(transform.position, destPos.transform.position) / delayTime;
    }


    void Update()
    {

        transform.position += dir.normalized * speed * Time.deltaTime;


        // 생성된 위치부터 목표 위치까지 barTime동안 가고싶다.
        //transform.position = Vector3.Lerp(transform.position, destPos.transform.position, Time.deltaTime );

        // 목표를 보고싶다.
        //transform.localRotation = Quaternion.Lerp(GetComponentInParent<Transform>().transform.rotation, destPos.transform.rotation, Time.time * speed);
        //GetComponentInParent<Transform>().transform.rotation = Quaternion.Lerp(GetComponentInParent<Transform>().transform.rotation, Quaternion.LookRotation(destPos.transform.position - transform.position.normalized),
        //          200 * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("DestroyLine"))
        {
            SpawnPoint72.note.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

}