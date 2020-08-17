using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Note72 : MonoBehaviour
{
    // 생성된 위치부터 목표 위치까지 ~~시간동안 가고싶다.
    // 생성되는 위치, 목표 위치, ~~시간
    GameObject destPos;
    public GameObject particle;
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("DestroyLine"))
        {
            SpawnPoint72.note.Add(gameObject);
            gameObject.SetActive(false);
            UIManager.Instance.combo = 0;
        }

        //if (other.gameObject.tag == "Player" && Player.COLOR == Player.State.Red)
        //{
        //    UIManager.Instance.combo += 1;
        //    SpawnPoint72.note.Add(gameObject);
        //    GameObject par = Instantiate(particle);
        //    par.transform.position = transform.position;
        //    par.transform.forward = -dir;
        //    transform.position = ResponPos.transform.position;
        //    gameObject.SetActive(false);

        //    // SideBar 색 바꾸기
        //    GameObject sideBarL = GameObject.Find("SideBarL_1");
        //    sideBarL.GetComponent<MeshRenderer>().material =  Resources.Load("72") as Material;
        //    GameObject sideBarR = GameObject.Find("SideBarR_1");
        //    sideBarR.GetComponent<MeshRenderer>().material = Resources.Load("72") as Material;
        //    GameObject RParent = GameObject.Find("SideBarR");
        //    GameObject LParent = GameObject.Find("SideBarL");

        //    for (int i = 0; i < RParent.transform.childCount; i++)
        //    {
        //        if (RParent.transform.GetChild(i).GetComponent<SideBar1>())
        //            RParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
        //        if (RParent.transform.GetChild(i).GetComponent<SideBar2>())
        //            RParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
        //        if (LParent.transform.GetChild(i).GetComponent<SideBar1>())
        //            LParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
        //        if (LParent.transform.GetChild(i).GetComponent<SideBar2>())
        //            LParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
        //    }

        //}


        if (other.gameObject.tag == "RightHand" && RightHand.COLOR == RightHand.State.Red)
        {
            

            UIManager.Instance.combo += 1;
            WordScale.Instance.ComboSize();
            NumberScale.Instance.ComboSize();
            SpawnPoint72.note.Add(gameObject);
            GameObject par = Instantiate(particle);
            par.transform.position = transform.position;
            par.transform.forward = -dir;
            gameObject.SetActive(false);

            // SideBar 색 바꾸기
            GameObject sideBarL = GameObject.Find("SideBarL_1");
            sideBarL.GetComponent<MeshRenderer>().material = Resources.Load("72") as Material;
            GameObject sideBarR = GameObject.Find("SideBarR_1");
            sideBarR.GetComponent<MeshRenderer>().material = Resources.Load("72") as Material;
            GameObject RParent = GameObject.Find("SideBarR");
            GameObject LParent = GameObject.Find("SideBarL");

            for (int i = 0; i < RParent.transform.childCount; i++)
            {
                if (RParent.transform.GetChild(i).GetComponent<SideBar1>())
                    RParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
                if (RParent.transform.GetChild(i).GetComponent<SideBar2>())
                    RParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
                if (LParent.transform.GetChild(i).GetComponent<SideBar1>())
                    LParent.transform.GetChild(i).GetComponent<SideBar1>().StartCoroutin();
                if (LParent.transform.GetChild(i).GetComponent<SideBar2>())
                    LParent.transform.GetChild(i).GetComponent<SideBar2>().StartCoroutin();
            }

        }
    }


}