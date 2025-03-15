using System;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public abstract class EventTask
    {
        private Action _onComplete;
        
        public void Run(Action onComplete)
        {
            _onComplete = onComplete;
            OnStart();
        }

        public void Complete()
        {
            OnComplete();
            _onComplete?.Invoke();
        }

        protected abstract void OnStart();

        protected virtual void OnComplete() { }
    }
    
    public class FinishTurnTask : EventTask
    {
        protected override void OnStart()
        {
            Complete();
        }

        protected override void OnComplete()
        {
            Debug.Log("Complete finish turn task");
        }
    }

    public class StartTurnTask : EventTask
    {
        protected override void OnStart()
        {
            Complete();
        }

        protected override void OnComplete()
        {
            Debug.Log("Complete start turn task");
        }
    }
}