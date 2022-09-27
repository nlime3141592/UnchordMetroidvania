using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageQueue : MonoBehaviour
{
    public GameObject prefab;

    public int msgCount = 3;
    private int msgCountBefore;

    public int autoFreetime = 500;
    private int leftAutoFreetime;

    public List<Text> txts;
    private Queue<string> msgs;

    void Start()
    {
        txts = new List<Text>();
        msgs = new Queue<string>();

        leftAutoFreetime = autoFreetime;
        prefab.SetActive(false);
        UpdatePool();
    }

    void FixedUpdate()
    {
        UpdatePool();
        Show();
        UpdateFreetime();
    }

    public void SendMessage(string msg)
    {
        if(msgs.Count == msgCount)
        {
            msgs.Dequeue();
            leftAutoFreetime = autoFreetime;
        }

        msgs.Enqueue(msg);
    }

    private void UpdatePool()
    {
        if(msgCount < 1)
            msgCount = 1;

        if(msgCountBefore != msgCount)
        {
            while(txts.Count < msgCount)
                txts.Add(NewText());

            for(int i = msgCount; i < txts.Count; i++)
                txts[i].gameObject.SetActive(false);
        }

        msgCountBefore = msgCount;
    }

    private void Show()
    {
        int i = 0;

        foreach(string str in msgs)
        {
            SetTextActive(i, true);
            txts[i].text = str;
            i++;
        }

        while(i < msgCount)
            SetTextActive(i++, false);
    }

    private void UpdateFreetime()
    {
        if(msgs.Count == 0)
            return;
        else if(leftAutoFreetime > 0)
            leftAutoFreetime--;
        else if(leftAutoFreetime == 0)
        {
            msgs.Dequeue();
            leftAutoFreetime = autoFreetime;
        }
    }

    private Text NewText()
    {
        GameObject obj = GameObject.Instantiate(prefab);
        obj.transform.SetParent(this.transform, false);
        return obj.GetComponentInChildren<Text>();
    }

    private void SetTextActive(int txtidx, bool enable)
    {
        txts[txtidx].transform.parent.gameObject.SetActive(enable);
    }
}