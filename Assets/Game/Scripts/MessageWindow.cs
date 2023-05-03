using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    [SerializeField]
    private Text _name;

    [SerializeField]
    private Text _content;

    public void Show(string name, string message)
    {
        if (_name is not null)
        {
            _name.text = name;
        }
        if (_content is not null)
        {
            _content.text = message;
        }
    }
}
