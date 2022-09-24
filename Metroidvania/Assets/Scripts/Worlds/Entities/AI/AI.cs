using System;

public abstract class AI
{
    public bool isCaptured => m_captured;
    public bool isPulsed => m_pulsed;
    public float capturedX => m_px;
    public float capturedY => m_py;

    protected Random p_prng => m_prng;

    private Random m_prng;
    private int m_avg;
    private int m_rng;

    private RandomPulse m_rp;
    private bool m_pulsed;

    private bool m_captured;
    private float m_px;
    private float m_py;

    protected AI(Random prng, int pulseAverage, int pulseRange)
    {
        m_prng = prng;
        m_avg = pulseAverage;
        m_rng = pulseRange;

        m_rp = new RandomPulse(prng, pulseAverage, pulseRange);
    }

    public void UpdateLogic()
    {
        m_rp.UpdateLogic();

        if(!m_rp.isEnabled)
            m_pulsed = false;
        else
            m_pulsed = true;

        OnPulse(m_captured, m_pulsed);
    }

    public virtual void Capture(float px, float py)
    {
        m_captured = true;
        m_px = px;
        m_py = py;
    }

    public virtual void Uncapture()
    {
        m_captured = false;
        m_px = 0.0f;
        m_py = 0.0f;
    }

    protected virtual void OnPulse(bool captured, bool pulsed) {}
}