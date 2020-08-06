using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // 필요속성 : 회전속도
    public float rotSpeed = 200;

    // 내가 내 각도를 직접 속성으로 저장한다.
    float mx;
    float my;

    // Update is called once per frame
    void Update()
    {
        // 사용자의 마우스 입력에 따라 물체를 회전시키고 싶다.
        // 1. 사용자의 입력에따라
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        // 2. 방향이 필요
        // 3. 회전시키고 싶다.
        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;
        my = Mathf.Clamp(my, -60, 60);
        // 최종 적용할때 회전 제약이 적용된 값을 넣고싶다.
        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}
