using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBar2 : MonoBehaviour
{
   

    float upMax = -5.9f;
    float downMax = -9.9f;
    float currentPositionX;
    float currentPositionY;
    float currentPositionZ;
    float direction = 3.0f; //이동속도+방향

    // Start is called before the first frame update
    void Start()
    {
        currentPositionX = transform.localPosition.x;
        currentPositionY = transform.localPosition.y;
        currentPositionZ = transform.localPosition.z;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        GetComponent<MeshRenderer>().material = parent.transform.GetChild(0).GetComponent<MeshRenderer>().material;

        currentPositionY -= Time.deltaTime * direction;

        if (currentPositionY >= upMax)
        {
            direction *= -1;
            currentPositionY = upMax;
        }

        else if (currentPositionY <= downMax)
        {
            direction *= -1;
            currentPositionY = downMax;
        }   

        transform.localPosition = new Vector3(currentPositionX, currentPositionY, currentPositionZ);

    }

    bool isCoroutine = true;

    public void StartCoroutin()
    {
        StartCoroutine(SlideShake());
    }

    IEnumerator SlideShake()
    {
        if (isCoroutine)
        {
            isCoroutine = !isCoroutine;

            for (int i = 0; i < 4; i++)
            {
                currentPositionZ += 1f;

                yield return null;

                currentPositionZ -= 1f;

                yield return null;

            }
        }

        isCoroutine = !isCoroutine;
    }
}
