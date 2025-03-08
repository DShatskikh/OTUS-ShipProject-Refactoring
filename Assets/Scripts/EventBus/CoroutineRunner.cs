using System.Collections;
using UnityEngine;

namespace Game
{
    public sealed class CoroutineRunner : ICoroutineRunner
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineRunner(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        
        public void StartCoroutine(IEnumerator coroutine)
        {
            _monoBehaviour.StartCoroutine(coroutine);
        }
    }
}