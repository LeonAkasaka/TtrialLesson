using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Animator))]
public class TalkAction : MonoBehaviour
{
    [field: SerializeField]
    [field: DisplayInfo(name = "Name")]
    public string Name { get; private set; }

    [field: SerializeField]
    [field: DisplayInfo(name = "Message")]
    public string Message { get; private set; }

    public void Talk() => Talk(default);

    public void Talk(Transform target)
    {
        if (FindAnyObjectByType<MessageWindow>() is { } messageWindow)
        {
            messageWindow.Show(Name, Message);
        }

        if (target)
        {
            transform.LookAt(target);
        }
    }
}