using UnityEngine;

namespace _Tutorial
{
    public class PickMoneyStepController : MonoBehaviour
    {
        [SerializeField]
        private BagMoney _bagMoney;
        
        [SerializeField]
        private GameObject _hint;
        
        [SerializeField]
        private GameObject _intro;
        
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
            if (step != TutorialStep.PICK_MONEY)
                return;

            _intro.SetActive(true);
            _hint.SetActive(true);
            _bagMoney.gameObject.SetActive(true);
            _bagMoney.PickedUpAction.AddListener(OnPickedUp);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.PICK_MONEY)
                return;
            
            _hint.SetActive(false);
        }

        private void OnPickedUp()
        {
            _tutorialState.FinishStep();
        }
    }
}