using System;

public class GridAI : AI
{
    public int gX => m_gx;
    public int gY => m_gy;
    public int pulsedState => m_pState;

    private GridRandom m_gprng;
    private int[] m_wVector;
    private int m_gx = -1;
    private int m_gy = -1;
    private int m_pState;

    public GridAI(Random prng, GridPoint[] points, int layers, int pulseAverage, int pulseRange)
    : base(prng, pulseAverage, pulseRange)
    {
        m_gprng = new GridRandom(prng, points, layers);
        m_wVector = new int[layers];
    }

    protected override void OnPulse(bool captured, bool pulsed)
    {
        m_gx = m_gprng.GetGX(capturedX);
        m_gy = m_gprng.GetGY(capturedY);

        if(pulsed)
            m_pState = -1;
        else if(captured)
            m_pState = m_gprng.GridSampling(m_gx, m_gy);
        else
            m_pState = m_NormalSampling();
    }

    public void SetGridWeight(int value, int gx, int gy, int layer)
    {
        m_gprng.SetWeight(value, gx, gy, layer);
    }

    public void SetNormalWeight(int value, int layer)
    {
        m_wVector[layer] = value;
    }

    private int m_NormalSampling()
    {
        int i, rndv;
        int si = -1;
        int sum = 0;
        int weight;

        for(i = 0; i < m_wVector.Length; i++)
        {
            weight = m_wVector[i];

            if(weight > 0)
            {
                sum += weight;
                rndv = p_prng.Next(0, sum);

                if(rndv < weight)
                    si = i;
            }
        }

        return si;
    }
}