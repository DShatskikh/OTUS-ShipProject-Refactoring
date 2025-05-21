using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Tutorial
{
    public sealed class CloseTutorialStepController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _screen;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private UnityEvent _action;
        
        private TutorialState _tutorialState;

        private void Awake()
        {
            _tutorialState = ServiceLocator.Get<TutorialState>();
            _tutorialState.OnStepStarted += OnStart;
            _tutorialState.OnStepFinished += OnFinish;
        }

        private void OnDestroy()
        {
            _tutorialState.OnStepStarted -= OnStart;
            _tutorialState.OnStepFinished -= OnFinish;
        }

        private void OnStart(TutorialStep step)
        {
            if (step != TutorialStep.CLOSE_TUTORIAL)
                return;

            _screen.SetActive(true);
            _closeButton.onClick.AddListener(Next);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.CLOSE_TUTORIAL)
                return;
            
            _screen.SetActive(false);
            _closeButton.onClick.RemoveListener(Next);
            _action.Invoke();
        }

        private void Next()
        {
            _tutorialState.FinishStep();
        }
    }
}