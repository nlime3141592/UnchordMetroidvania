using System;
using System.Collections.Generic;
using UnityEngine;

// PassiveEntity.cs만 UnityEngine을 참조하고 있어서, 나머지 파일들은 다 dll파일로 따로 빼서 옮겨써도 됨.

// 수동 엔티티: AI에 의해 움직이는 모든 개체들
public class PassiveEnemy : MonoBehaviour
{
    [Header("Settings")]
    public SpriteRenderer spIn;
    public SpriteRenderer spOut;
    public LTRB ltrbIn;
    public LTRB ltrbOut;

    public int avgFrame;
    public int rngFrame;

    [Header("For Debug")]
    public bool DEBUG_CAPTURED_1;
    public bool DEBUG_CAPTURED_2;
    public bool DEBUG_IS_CAPTURED;

    private Collider2D[] hOut;

    private RectAI m_ai;

    private void Start()
    {
        System.Random prng = new System.Random();
        m_ai = new RectAI(prng, ltrbIn, ltrbOut, avgFrame, rngFrame);
    }

    private void FixedUpdate()
    {
        SetRenderer(spIn, ltrbIn);
        SetRenderer(spOut, ltrbOut);

        // Detect Entity
        float ocx = transform.position.x + ltrbOut.dx * 0.5f;
        float ocy = transform.position.y + ltrbOut.dy * 0.5f;

        float osx = ltrbOut.sx;
        float osy = ltrbOut.sy;

        Vector2 ocv = Vector2.zero;
        Vector2 osv = Vector2.zero;

        ocv.Set(ocx, ocy);
        osv.Set(osx, osy);

        hOut = Physics2D.OverlapBoxAll(ocv, osv, 0.0f, 1 << LayerMask.NameToLayer("Entity"));

        Collider2D p;
        if(isOverlapOnBox(hOut, out p))
            m_ai.Capture(p.transform.position.x, p.transform.position.y);
        else
            m_ai.Uncapture();

        DEBUG_IS_CAPTURED = m_ai.isCaptured;
        DEBUG_CAPTURED_1 = m_ai.isInArea1;
        DEBUG_CAPTURED_2 = m_ai.isInArea2;

        // Update AI
        m_ai.UpdateLogic(transform.position.x, transform.position.y);

        // Check AI pulsed
        if(m_ai.isPulsed) Debug.Log("Enemy Pulsed.");
    }

    private void SetRenderer(SpriteRenderer trans, LTRB ltrb)
    {
        if(trans == null) return;

        float dx = ltrb.dx;
        float dy = ltrb.dy;
        float px = transform.position.x + dx * 0.5f;
        float py = transform.position.y + dy * 0.5f;

        trans.transform.position = new Vector3(px, py, trans.transform.position.z);
        trans.transform.localScale = new Vector3(ltrb.sy * 2.0f, ltrb.sy * 2.0f, 1.0f);
    }

    private bool isOverlapOnBox(Collider2D[] hs, out Collider2D col)
    {
        foreach(Collider2D h in hs)
        {
            GameObject obj = h.gameObject;

            if(obj.tag == "Player")
            {
                col = h;
                return true;
            }
        }

        col = null;
        return false;
    }
}