using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어를 이동시키고싶다
    public float speed = 5;
    Renderer playerColor;

    // 미사일 발사하고싶다
    // 필요요소 - rb, 미사일팩토리, 발사하는곳
    public GameObject missileFactory;
    public Transform firePosition;
    

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

        // 스페이스바 누르면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Bar");
            // 미사일 만들어서
            GameObject missile = Instantiate(missileFactory);
            // 발사위치에 가져다 놓고싶다.
            missile.transform.position = firePosition.position;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Notes")
        {
            print("123");
            other.gameObject.SetActive(false);


        }
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Notes")
    //    {
    //        print("123");
    //        other.gameObject.SetActive(false);

    //    }
    //}
}
