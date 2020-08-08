using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    //싱글톤
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Canvas start;    // 시작상태 UI캔버스
    public Canvas howToPlay;// 게임 방법 상태 UI캔버스
    public Canvas select;   // 음악 선택 상태 UI캔버스(옆에 옵션창도 같이)
    public Canvas onPlay;   // 리듬게임 플레이 상태의 ui 캔버스
    public Text combo;      // 노트 콤보 수
    public Canvas result;   // 게임결과 UI캔버스

    public enum UIState
    {
        start,
        howToPlay,
        select,
        onPlay,
        result
    }
    public UIState curUIState; //현재 UI상태

    void Start()
    {
        curUIState = UIState.start;
        start.enabled = false;
        howToPlay.enabled = false;
        select.enabled = false;
        onPlay.enabled = false;
        result.enabled = false;
    }

    void Update()
    {
        switch (curUIState)  // UI상태머신의 목차
        {
            case UIState.start:
                start.enabled = true;
                howToPlay.enabled = false;
                select.enabled = false;
                break;

            case UIState.howToPlay:
                start.enabled = false;
                howToPlay.enabled = true;
                break;

            case UIState.select:
                start.enabled = false;
                howToPlay.enabled = false;
                select.enabled = true;
                break;

            case UIState.onPlay:
                select.enabled = false;
                onPlay.enabled = true;
                combo.text = "0";
                break;

            case UIState.result:
                onPlay.enabled = false;
                result.enabled = true;
                break;
        }
    }
}
