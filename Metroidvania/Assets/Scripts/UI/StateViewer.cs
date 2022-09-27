using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateViewer : MonoBehaviour
{
    public Text txt;
    public Player pl;
    private List<string> state_kr;
    private List<string> state_en;

    private int lang;

    void Start()
    {
        lang = 0;

        state_kr = new List<string>();
        state_en = new List<string>();

        SetKr();
        SetEn();
    }

    private void SetKr()
    {
        state_kr.Add("정지(바닥)");
        state_kr.Add("정지(바닥, 장시간)");
        state_kr.Add("앉기");
        state_kr.Add("고개 들기");
        state_kr.Add("걷기");
        state_kr.Add("달리기");
        state_kr.Add("자유 낙하");
        state_kr.Add("글라이딩");
        state_kr.Add("벽 붙기");
        state_kr.Add("벽 슬라이딩");
        state_kr.Add("난간 오르기(머리)");
        state_kr.Add("난간 오르기(몸)");
        state_kr.Add("점프(바닥, 상향)");
        state_kr.Add("점프(바닥, 하향)");
        state_kr.Add("구르기");
        state_kr.Add("공중 점프");
        state_kr.Add("대쉬");
        state_kr.Add("내려 찍기");
        state_kr.Add("벽 점프");
        state_kr.Add("걷기 멈추기");
        state_kr.Add("달리기 멈추기");
    }

    private void SetEn()
    {
        state_en.Add("Idle Ground");
        state_en.Add("Idle Ground Long");
        state_en.Add("Sit");
        state_en.Add("Head Up");
        state_en.Add("Walk");
        state_en.Add("Run");
        state_en.Add("Free Fall");
        state_en.Add("Gliding");
        state_en.Add("Idle Wall");
        state_en.Add("Wall Sliding");
        state_en.Add("Ledge Climb Head");
        state_en.Add("Ledge Climb Body");
        state_en.Add("Jump Ground");
        state_en.Add("Jump Down");
        state_en.Add("Roll");
        state_en.Add("Jump Air");
        state_en.Add("Dash");
        state_en.Add("Take Down");
        state_en.Add("Jump Wall");
        state_en.Add("Walk Up");
        state_en.Add("Run Up");
    }

    public void ChangeLanguage()
    {
        int l = lang + 1;

        lang = l % 2;
    }

    private void Update()
    {
        if(pl == null || txt == null)
            return;

        View(pl.currentState);
    }

    private void View(int state)
    {
        switch(lang)
        {
            case 0:
                Show(state_kr[state]);
                break;
            case 1:
                Show(state_en[state]);
                break;

            default:
                Show(state_en[state]);
                break;
        }
    }

    private void Show(string state)
    {
        txt.text = string.Format("Current State:\n{0}", state);
    }
}