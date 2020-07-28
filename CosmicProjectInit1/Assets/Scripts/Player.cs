using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어를 이동시키고싶다
    public float speed = 5;
    Renderer playerColor;
    

    // 플레이어와 충돌하는 물체들을 다 부수고싶다

    void Start()
    {
        playerColor = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        //Move();

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeColor();
        }
        
    }

    //private void Move()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    Vector3 dir = new Vector3(h, 0, 0);
    //    dir.Normalize();

    //    transform.position += dir * speed * Time.deltaTime;
    //}

    //마우스 드래그에 따라 움직이는 플레이어 객체
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.6f);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void ChangeColor()
    {
        if (playerColor.material.color != Color.red) playerColor.material.color = Color.red;
        else playerColor.material.color = Color.blue;
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
