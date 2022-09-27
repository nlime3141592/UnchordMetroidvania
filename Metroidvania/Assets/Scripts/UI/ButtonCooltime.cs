using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooltime : MonoBehaviour
{
    public Button btn;
    public Image cooltimeMask;
    public int cooltime = 150;
    public int leftCooltime;
    private float dv;

    void Start()
    {
        leftCooltime = Min(cooltime, 30);
        UpdateButton();
    }

    void FixedUpdate()
    {
        UpdateButton();
    }

    public void SetCooltime()
    {
        leftCooltime = cooltime;
    }

    private void UpdateButton()
    {
        if(btn == null || cooltimeMask == null)
            return;

        if(leftCooltime == 0)
            return;

        leftCooltime--;

        dv = (float)leftCooltime / (float)cooltime;
        cooltimeMask.fillAmount = dv;
        btn.interactable = leftCooltime == 0;
    }

    private int Min(int a, int b) => a < b ? a : b;
}
