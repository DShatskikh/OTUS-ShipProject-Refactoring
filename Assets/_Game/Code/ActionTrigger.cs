using UnityEngine;
using UnityEngine.Events;

public sealed class ActionTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _action;
    
    public UnityEvent GetAction => _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _action.Invoke();
        }
    }
}