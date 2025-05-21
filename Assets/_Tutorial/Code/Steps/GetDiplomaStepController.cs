using UnityEngine;
using UnityEngine.UI;

namespace _Tutorial
{
    public sealed class GetDiplomaStepController : MonoBehaviour
    {
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
        private GameObject _endScreen;

        [SerializeField]
        private Button _closeButton;
        
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
            if (step != TutorialStep.GET_DIPLOMA)
                return;

            _tutorialShop.SetActive(true);
            _buyButton.onClick.AddListener(Next);
            _hint.SetActive(true);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.GET_DIPLOMA)
                return;
            
            _buyButton.interactable = false;
            _player.AddMoney(-33000);
            _arrow.SetActive(false);
            _arrowClose.SetActive(true);
            _hint.SetActive(false);
            _tutorialShop.SetActive(false);
            _endScreen.SetActive(true);
        }

        private void Next()
        {
            _closeButton.onClick.AddListener(OnClose);
            _tutorialState.FinishStep(false);
        }

        private void OnClose()
        {
            _endScreen.SetActive(false);
            _tutorialState.NextStep();
            _player.enabled = true;
        }
    }
}
