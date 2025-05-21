using System.Collections;
using TMPro;
using UnityEngine;

namespace _Tutorial
{
    public sealed class WaitingNewMoneyStepController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timerLabel;
        
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
            if (step != TutorialStep.WAITING_NEW_MONEY)
                return;

            StartCoroutine(AwaitTimer());
            
            _hint.SetActive(true);
        }

        private void OnFinish(TutorialStep step)
        {
            if (step != TutorialStep.WAITING_NEW_MONEY)
                return;
            
            _hint.SetActive(false);
        }

        private IEnumerator AwaitTimer()
        {
            var timer = 5;
            
            while (timer > 0)
            {
                timer -= 1;
                _timerLabel.text = $"Времени до ЗП {timer} сек";
                yield return new WaitForSeconds(1);
            }
            
            _tutorialState.FinishStep();
        }
    }
}