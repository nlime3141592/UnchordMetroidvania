using UnityEngine;

public class MessageSender : MonoBehaviour
{
    public MessageQueue queue;
    public string msg;

    public void ToQueue()
    {
        queue.SendMessage(msg);
    }
}