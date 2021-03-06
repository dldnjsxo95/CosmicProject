﻿using System.Collections;
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

    public GameObject start;    // 시작상태 UI캔버스
    public GameObject howToPlay;// 게임 방법 상태 UI캔버스
    public GameObject select;   // 음악 선택 상태 UI캔버스(옆에 옵션창도 같이)
    public GameObject onPlay;   // 리듬게임 플레이 상태의 ui 캔버스
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    public Text comboTxt;      // UI 중 "combo" 글자
    public Text comboNum;      // UI 중 콤보 수
    public Canvas result;   // 게임결과 UI캔버스
>>>>>>> parent of ebc502e... 점수 추가
=======
    public Text comboTxt;      // UI 중 "combo" 글자
    public Text comboNum;      // UI 중 콤보 수
    public Canvas result;   // 게임결과 UI캔버스
>>>>>>> parent of ebc502e... 점수 추가
=======
    public Text comboTxt;      // UI 중 "combo" 글자
    public Text comboNum;      // UI 중 콤보 수
    public Canvas result;   // 게임결과 UI캔버스
>>>>>>> parent of ebc502e... 점수 추가

    public int combo = 0; //콤보수

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        howToPlay.SetActive(false);
        select.SetActive(false);
        onPlay.SetActive(false);
=======
        start.SetActive(false);
        howToPlay.SetActive(false);
        select.SetActive(false);
        onPlay.SetActive(false);
        result.enabled = false;
>>>>>>> parent of ebc502e... 점수 추가
=======
        start.SetActive(false);
        howToPlay.SetActive(false);
        select.SetActive(false);
        onPlay.SetActive(false);
        result.enabled = false;
>>>>>>> parent of ebc502e... 점수 추가
=======
        start.SetActive(false);
        howToPlay.SetActive(false);
        select.SetActive(false);
        onPlay.SetActive(false);
        result.enabled = false;
>>>>>>> parent of ebc502e... 점수 추가
    }

    void Update()
    {
        switch (curUIState)  // UI상태머신의 목차
        {
            case UIState.start:
                start.SetActive(true);
                howToPlay.SetActive(false);
                select.SetActive(false);
                break;

            case UIState.howToPlay:
                start.SetActive(false);
                howToPlay.SetActive(true);
                break;

            case UIState.select:
                start.SetActive(false);
                howToPlay.SetActive(false);
                select.SetActive(true);
                break;

            case UIState.onPlay:
                select.SetActive(false);
                onPlay.SetActive(true);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of ebc502e... 점수 추가
=======
>>>>>>> parent of ebc502e... 점수 추가
                if (combo == 0)
                {
                    comboTxt.text = " ";
                    comboNum.text = " ";
                }
                else
                {
                    comboTxt.text = "Combo";
                    comboNum.text = combo.ToString();
                }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of ebc502e... 점수 추가
=======
>>>>>>> parent of ebc502e... 점수 추가
=======
>>>>>>> parent of ebc502e... 점수 추가
                break;

            case UIState.result:
                onPlay.SetActive(false);
                result.enabled = true;
                break;
        }
    }
}
