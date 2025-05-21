using UnityEngine;
using UnityEngine.Events;

public sealed class BagMoney : MonoBehaviour
{
    [SerializeField]
    private int _money = 15;
    
    public UnityEvent PickedUpAction;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.AddMoney(_money);
            PickedUpAction.Invoke();
            Destroy(gameObject);
        }
    }
}