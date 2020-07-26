using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어를 이동시키고싶다
    public float speed = 5;

    

    // 플레이어와 충돌하는 물체들을 다 부수고싶다

    void Start()
    {
        
    }

    void Update()
    {
        Move();
       
        
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Notes")
    //    {
    //        print("123");
    //        other.gameObject.SetActive(false);


    //    }
    //}
    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Notes")
    //    {
    //        print("123");
    //        other.gameObject.SetActive(false)

    //    }
    //}
}
