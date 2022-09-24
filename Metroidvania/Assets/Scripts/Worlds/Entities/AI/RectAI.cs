using System;

public class RectAI : AI
{
    public bool isInArea1 {get; private set;} = false;
    public bool isInArea2 {get; private set;} = false;

    private LTRB m_area1; // 사거리 내 탐지 영역
    private LTRB m_area2; // 플레이어 탐지 영역

    public RectAI(Random prng, LTRB area1, LTRB area2, int pulseAverage, int pulseRange)
    : base(prng, pulseAverage, pulseRange)
    {
        m_area1 = area1;
        m_area2 = area2;
    }

    protected override void OnPulse(bool captured, bool pulsed)
    {
        if(!captured)
        {
            isInArea1 = false;
            isInArea2 = false;
        }
        else
        {
            isInArea1 = isInArea(m_area1);
            isInArea2 = isInArea(m_area2);
        }
    }

    private bool isInArea(LTRB ltrb)
    {
        float dx = capturedX - currentX;
        float dy = capturedY - currentY;

        if(dx < -ltrb.l || dx > ltrb.r)
            return false;
        else if(dy < -ltrb.b || dy > ltrb.t)
            return false;
        else
            return true;
    }
}
