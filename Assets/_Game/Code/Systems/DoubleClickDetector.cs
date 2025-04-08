using System;
using UnityEngine;
using Zenject;

namespace Game.Systems
{
    public sealed class DoubleClickDetector : ITickable
    {
        private float _doubleClickTime = 0.2f;
        private float _lastClickTime = 0f;

        public event Action DoubleClick;
        
        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                float timeSinceLastClick = Time.time - _lastClickTime;

                if (timeSinceLastClick <= _doubleClickTime)
                {
                    DoubleClick?.Invoke();
                }

                _lastClickTime = Time.time;
            }
        }
    }
}