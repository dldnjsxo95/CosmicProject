using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Clone84 : MonoBehaviour
{
    float speed = 8f;
    Vector3 dir;
    GameObject destPos;

    private void OnEnable()
    {
      
    }


    void Update()
    {

        transform.position += transform.forward* speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("DestroyLine"))
        {
            Destroy(gameObject);
        }
    }

}