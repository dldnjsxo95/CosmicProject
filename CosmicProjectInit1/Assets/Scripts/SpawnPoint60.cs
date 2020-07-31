using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint60 : MonoBehaviour
{
    //60이 0.12초 지속 2초주

    //72가 2초 지속 8초주기

    // 시작하면 게임 오브젝트 생성 

    // 2초에 하나씩 생성 

    public GameObject notePrefab; // 노트 프리팹
    public GameObject noteParent; // 노트가 들어가 있을 임시공간
    public int numberOfNote = 0; // 오브젝트 풀로 생성할 노트의 개수
    public static List<GameObject> note = new List<GameObject>(); // 생성된 노트의 리스트 배열

    public float makeDelayTime = 0.12f; // 노트의 간격 시간

    void Awake()
    {
        // 생성할 노트의 개수만큼 반복
        for (int i = 0; i < numberOfNote; i++)
        {
            note.Add(Instantiate(notePrefab)); // 리스트 배열에 생성된 노트를 넣어준다.
            note[i].transform.SetParent(noteParent.transform);// 금방 생성된 노트를 noteParant 오브젝트에 넣어준다. 
            note[i].SetActive(false);// 생성된 노트의 상태를 false로 만들어준다.
        }
    }

    private void OnEnable()
    {
        StartCoroutine(GenerateNote()); // 해당 오브젝트가 켜지면 코루틴을 시작한다.
    }

    IEnumerator GenerateNote()
    {
        while (true)
        {
            note[0].transform.position = transform.position; // 리스트 배열 맨 앞의 노트의 위치를 자신의 위치로 가져온다.
            note[0].SetActive(true); // 해당 노트의 상태를 true 상태로 바꾸어준다. 
            note.RemoveAt(0); // 해당 노트를 배열에서 제거한다.

            yield return new WaitForSeconds(makeDelayTime); // 지정한 시간에 한번씩 반복되도록 한다.
        }
    }

    private void OnDisable()
    {
        StopCoroutine(GenerateNote()); // 자신의 상태가 꺼지면 코루틴을 멈춘다.
    }

}
