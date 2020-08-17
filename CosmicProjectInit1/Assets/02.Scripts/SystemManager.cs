using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //싱글톤
    public static SystemManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    //int combo = 0; //콤보수

    public enum State
    {
        start,     //시작로비화면
        howToPlay, //게임방법
        select,    //음악선택
        onPlay,    //게임진행
        result     //결과창
    }

    public State nowState; //현재 게임 상태

    void Start()
    {
        nowState = State.start; // 시작할땐 start 상태
    }

    void Update()
    {
        switch (nowState)  // 전체 상태머신의 목차
        {
            case State.start:
                break;
            case State.howToPlay:
                break;
            case State.select:
                break;
            case State.onPlay:
                OnPlayState();
                break;
            case State.result:
                ResultState();
                break;
        }
    }

    public void OnPlayState()  //게임플레이 상태
    {
        UIManager.Instance.curUIState = UIManager.UIState.onPlay;

        //음악이 끝나면 결과창으로 넘어간다
        //nowState = State.result;
    }

    public void ResultState()  //결과창 상태
    {
        UIManager.Instance.curUIState = UIManager.UIState.result;
    }


    /* -------버튼 기능------- */

    public void OnClickHowToPlay()  // 게임방법으로 전환
    {
        nowState = State.howToPlay;
    }

    public void OnClickSelect()  // 음악선택창으로 전환
    {
        nowState = State.select;
    }

    public void OnClickGoToTitle()  // 시작로비화면으로 전환
    {
        nowState = State.start;
    }

    public void OnClickExit()  // 게임 종료
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
