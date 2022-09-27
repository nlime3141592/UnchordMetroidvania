using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSceneManager : Manager
{
    public Text loadMessage;

    protected override void Start()
    {
        StartCoroutine(PreProcess());
    }

    protected override void SetManager()
    {
        ManagerHub.SetManagerSceneManager(this);
    }

    protected override void ResetManager()
    {
        ManagerHub.SetManagerSceneManager(null);
    }

    private IEnumerator PreProcess()
    {
        string datFilePath = Application.persistentDataPath + "/DataTable.txt";
        loadMessage.gameObject.SetActive(true);

        loadMessage.text = "File Load Now ...";
        PlayerExtensions.CreateDataTable(datFilePath);
        while(!System.IO.File.Exists(datFilePath))
            yield return new WaitForFixedUpdate();

        MapManager.Open(1, true, null);

        loadMessage.gameObject.SetActive(false);
    }
}