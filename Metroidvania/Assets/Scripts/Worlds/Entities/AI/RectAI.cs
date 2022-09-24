using System;

public class RectAI
{
    public bool isInArea1 {get; private set;} = false;
    public bool isInArea2 {get; private set;} = false;

    private LTRB m_area1; // 사거리 내 탐지 영역
    private LTRB m_area2; // 플레이어 탐지 영역

    public RectAI(LTRB area1, LTRB area2)
    {
        m_area1 = area1;
        m_area2 = area2;
    }
}
