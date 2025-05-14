using TMPro;
using UnityEngine;

public sealed class Table : MonoBehaviour
{
    [SerializeField]
    private string _message;
    
    [SerializeField]
    private TextMeshPro _messageLabel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            ShowMessage(_message);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            HideMessage();
        }
    }
    
    private void ShowMessage(string message)
    {
        _messageLabel.gameObject.SetActive(true);
        _messageLabel.text = message;
    }

    private void HideMessage()
    {
        _messageLabel.gameObject.SetActive(false);
    }
}