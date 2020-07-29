using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float speed = 5; //속도
    Renderer playerColor; //렌더러속성
    public static bool isRed = true; //색 판별
    public GameObject blade; //블레이드
    public GameObject bladeShape; //블레이드 가시성을 위한 형체

    // 미사일 발사하고싶다
    // 필요요소 - rb, 미사일팩토리, 발사하는곳
    //public GameObject missileFactory;
    //public Transform firePosition;
    

    void Start()
    {
        playerColor = gameObject.GetComponent<Renderer>();
        blade.SetActive(false);
        bladeShape.SetActive(false);
    }

    void Update()
    {
        //A키를 누르면 플레이어 색 변경
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeColor();
        }

        //S키를 누르는 동안에만 블레이드 활성화
        if (Input.GetKey(KeyCode.S))
        {
            blade.SetActive(true);
            bladeShape.SetActive(true);
        }
        else
        {
            blade.SetActive(false);
            bladeShape.SetActive(false);
        }

        //// 스페이스바 누르면
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    print("Bar");
        //    // 미사일 만들어서
        //    GameObject missile = Instantiate(missileFactory);
        //    // 발사위치에 가져다 놓고싶다.
        //    missile.transform.position = firePosition.position;

        //}
    }

    //마우스 드래그에 따라 움직이는 플레이어 객체
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.6f);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    //색 바꿔주기
    private void ChangeColor()
    {
        if (playerColor.material.color != Color.red)
        {
            playerColor.material.color = Color.red;
            isRed = true;
        }
        else
        {
            playerColor.material.color = Color.blue;
            isRed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedNotes")
        {
            if (isRed)
            {
                SpawnPoint72.note.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag == "BlueNotes")
        {
            if (!isRed)
            {
                SpawnPoint60.note.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
    }
}
