using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : Manager
{
    public Transform initTransform;

    public static AsyncOperation Open(int mapIdx, bool allowSceneActivation, Action<AsyncOperation> onComplete)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(mapIdx, LoadSceneMode.Additive);
        op.allowSceneActivation = allowSceneActivation;
        op.completed += onComplete;
        return op;
    }

    public static AsyncOperation Close(int mapIdx, bool allowSceneActivation, Action<AsyncOperation> onComplete)
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(mapIdx);
        op.allowSceneActivation = allowSceneActivation;
        op.completed += onComplete;
        return op;
    }

    public PolygonCollider2D virtualCameraBoundary;

    protected override void SetManager()
    {
        ManagerHub.SetMapManager(this);
    }

    protected override void ResetManager()
    {
        ManagerHub.SetMapManager(null);
    }
}