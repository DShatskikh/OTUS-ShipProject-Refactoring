using System;
using UnityEngine;

namespace _Tutorial
{
    public sealed class TutorialState
    {
        private const string SAVE_KEY = "TutorialState";
        
        public event Action<TutorialStep> OnStepStarted;
        public event Action<TutorialStep> OnStepFinished;
        public event Action OnCompleted;

        public bool IsCompleted { get; private set; }
        public TutorialStep CurrentStep { get; private set; }

        [Serializable]
        public struct Data
        {
            public TutorialStep CurrentStep;
            public bool IsCompleted;
        }
        
        public TutorialState()
        {
            var loadData = PlayerPrefs.GetString(SAVE_KEY);

            if (loadData != string.Empty)
            {
                var data = JsonUtility.FromJson<Data>(loadData);

                IsCompleted = data.IsCompleted;
                CurrentStep = data.CurrentStep;
            }
        }

        public void Start()
        {
            if (CurrentStep == TutorialStep.START)
            {
                NextStep();
                return;
            }
            
            OnStepStarted?.Invoke(CurrentStep);
        }
        
        public void NextStep()
        {
            CurrentStep++;

            Debug.Log("NextStep " + CurrentStep);
            
            if (CurrentStep == TutorialStep.END)
            {
                IsCompleted = true;
                OnCompleted?.Invoke();
            }
            else
            {
                OnStepStarted?.Invoke(CurrentStep);
            }

            var saveData = JsonUtility.ToJson(GetData());
            PlayerPrefs.SetString(SAVE_KEY, saveData);
            PlayerPrefs.Save();
        }

        public void FinishStep(bool moveNext = true)
        {
            OnStepFinished?.Invoke(CurrentStep);
            
            if (moveNext)
                NextStep();
        }

        private Data GetData()
        {
            return new Data()
            {
                IsCompleted = IsCompleted,
                CurrentStep = CurrentStep
            };
        }
    }
}