using UnityEngine;
using UnityEngine.Events;

namespace _Tutorial
{
    public sealed class ActionNotEntTutorial : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _action;
        
        private void Start()
        {
            if (!ServiceLocator.Get<TutorialState>().IsCompleted)
            {
                _action.Invoke();
            }
        }
    }
}