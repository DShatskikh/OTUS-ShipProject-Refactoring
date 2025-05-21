using UnityEngine;

namespace _Tutorial
{
    public sealed class MoveToPizzaStepController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _hint;

        [SerializeField]
        private GameObject _arrow;
        
        [SerializeField]
        private ActionTrigger _openShopTrigger;
        
        [SerializeField]
        private ActionTrigger _openTutorialShopTrigger;
        
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
            _openTutorialShopTrigger.GetAction.RemoveListener(Next);
        }

        private void OnStart(TutorialStep step)
        {
            if (step != TutorialStep.MOVE_TO_PIZZA)
                return;

            _hint.SetActive(true);
            _arrow.SetActive(true);
            _openShopTrigger.gameObject.SetActive(false);
            _openTutorialShopTrigger.gameObject.SetActive(true);
            _openTutorialShopTrigger.GetAction.AddListener(Next);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.MOVE_TO_PIZZA)
                return;
            
            _openTutorialShopTrigger.gameObject.SetActive(false);
            _arrow.SetActive(false);
            _hint.SetActive(false);
        }

        private void Next()
        {
            _tutorialState.FinishStep();
        }
    }
}