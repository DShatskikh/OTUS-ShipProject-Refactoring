using UnityEngine;

namespace _Tutorial
{
    public sealed class MoveToOTUSStepController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _hint;

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
            if (step != TutorialStep.MOVE_TO_OTUS)
                return;

            _hint.SetActive(true);
            _openShopTrigger.gameObject.SetActive(false);
            _openTutorialShopTrigger.gameObject.SetActive(true);
            _openTutorialShopTrigger.GetAction.AddListener(Next);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.MOVE_TO_OTUS)
                return;
            
            _openTutorialShopTrigger.gameObject.SetActive(false);
            _hint.SetActive(false);
        }

        private void Next()
        {
            _tutorialState.FinishStep();
        }
    }
}