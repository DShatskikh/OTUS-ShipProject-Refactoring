using UnityEngine;
using UnityEngine.UI;

namespace _Tutorial
{
    public sealed class BuyTutorialStepController : MonoBehaviour
    {
        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private GameObject _arrow;

        [SerializeField]
        private GameObject _arrowClose;
        
        [SerializeField]
        private Button _buyButton;

        [SerializeField]
        private GameObject _hint;

        [SerializeField]
        private GameObject _tutorialShop;
        
        [SerializeField]
        private GameObject _hint2;

        [SerializeField]
        private GameObject _arrow2;
        
        [SerializeField]
        private ActionTrigger _openShopTrigger;
        
        [SerializeField]
        private ActionTrigger _openTutorialShopTrigger;
        
        private TutorialState _tutorialState;
        private Player _player;

        private void Awake()
        {
            _tutorialState = ServiceLocator.Get<TutorialState>();
            _player = ServiceLocator.Get<Player>();
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
            if (step != TutorialStep.BUY_TUTORIAL)
                return;

            _hint2.SetActive(true);
            _arrow2.SetActive(true);
            _openShopTrigger.gameObject.SetActive(false);
            _openTutorialShopTrigger.gameObject.SetActive(true);
            _openTutorialShopTrigger.GetAction.AddListener(OnTriggerOTUS);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.BUY_TUTORIAL)
                return;

            _closeButton.interactable = true;
            _closeButton.onClick.AddListener(OnClose);
            _buyButton.interactable = false;
            _player.AddMoney(-33000);
            _arrow.SetActive(false);
            _arrowClose.SetActive(true);
            _hint.SetActive(false);
        }

        private void OnTriggerOTUS()
        {
            _openTutorialShopTrigger.gameObject.SetActive(false);
            _hint2.SetActive(false);
            _arrow2.SetActive(false);
            
            _tutorialShop.SetActive(true);
            _buyButton.onClick.AddListener(Next);
            _hint.SetActive(true);
        }
        
        private void Next()
        {
            _tutorialState.FinishStep(false);
        }

        private void OnClose()
        {
            _tutorialState.NextStep();
        }
    }
}