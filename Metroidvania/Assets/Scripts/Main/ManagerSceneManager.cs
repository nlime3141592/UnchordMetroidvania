using System;
using System.Collections;
using UnityEngine;

public class ManagerSceneManager : Manager
{

    protected override void Start()
    {
        MapManager.Open(1, true, null);
    }

    protected override void SetManager()
    {
        ManagerHub.SetManagerSceneManager(this);
    }

    protected override void ResetManager()
    {
        ManagerHub.SetManagerSceneManager(null);
    }
}