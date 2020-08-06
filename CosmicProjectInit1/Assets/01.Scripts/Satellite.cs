using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    //기준 행성
    public GameObject Planet;
    //회전 속도
    public float speed;             

    private void Update()
    {
        

        OrbitAround();

        Rotation();

    }

    private void Rotation()
    {
        // 태양열 플레이트
        transform.GetChild(4).transform.Rotate(new Vector3(10f, 0, 0) * Time.deltaTime);
        transform.GetChild(5).transform.Rotate(new Vector3(10f, 0, 0) * Time.deltaTime);
        // 본체
        //transform.Rotate(new Vector3(f, 0, 0) * Time.deltaTime);
    }

    void OrbitAround()
    {
        transform.RotateAround(Planet.transform.position, Vector3.down, speed * Time.deltaTime);
    }
    // RotateAround(Vector3 point, Vector3 axis, float angle)

}
