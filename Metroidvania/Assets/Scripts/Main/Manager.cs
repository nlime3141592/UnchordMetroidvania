using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        SetManager();
    }

    protected virtual void Start()
    {

    }

    protected virtual void OnDestroy()
    {
        ResetManager();
    }

    protected abstract void SetManager();
    protected abstract void ResetManager();
}