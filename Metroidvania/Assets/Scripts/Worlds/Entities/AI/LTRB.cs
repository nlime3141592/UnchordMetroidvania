using System;

[Serializable]
public struct LTRB
{
    public float l;
    public float t;
    public float r;
    public float b;

    public float dx => this.r - this.l;
    public float dy => this.t - this.b;
    public float sx => this.r + this.l;
    public float sy => this.t + this.b;
}