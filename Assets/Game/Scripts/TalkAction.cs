using UnityEngine;
using UnityEngine.Rendering;

public class TalkAction : MonoBehaviour
{
    [field: SerializeField]
    [field: DisplayInfo(name = "Name")]
    public string Name { get; private set; }

    [field: SerializeField]
    [field: DisplayInfo(name = "Message")]
    public string Message { get; private set; }

    public void Talk()
    {
        if (FindObjectOfType<MessageWindow>() is { } messageWindow)
        {
            messageWindow.Show(Name, Message);
        }
    }
}