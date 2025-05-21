using UnityEngine;

namespace _Tutorial
{
    public sealed class PickNewMoneyStepController : MonoBehaviour
    {
        [SerializeField]
        private BagMoney _bagMoney;
        
        [SerializeField]
        private GameObject _hint;
        
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
            if (step != TutorialStep.PICK_NEW_MONEY)
                return;

            _hint.SetActive(true);
            _bagMoney.gameObject.SetActive(true);
            _bagMoney.PickedUpAction.AddListener(OnPickedUp);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.PICK_NEW_MONEY)
                return;
            
            _hint.SetActive(false);
        }

        private void OnPickedUp()
        {
            _tutorialState.FinishStep();
        }
    }
}