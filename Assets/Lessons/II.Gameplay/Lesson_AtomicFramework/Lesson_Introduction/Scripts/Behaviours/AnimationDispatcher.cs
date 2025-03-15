using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class AnimationDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            this.OnEventReceived?.Invoke(key);
        }
    }
}