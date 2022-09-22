using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private Image img;
    private Color m_color;

    void Start()
    {
        img = GetComponent<Image>();
        m_color = img.color;
    }

    void FixedUpdate()
    {
        m_color.a = PlayerSceneManager.fadeAlpha;
        img.color = m_color;
    }
}
