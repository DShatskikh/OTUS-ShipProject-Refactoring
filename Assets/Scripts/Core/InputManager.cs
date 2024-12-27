using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IGameUpdateListener, IGameFixedUpdateListener
    {
        private float _horizontalDirection;

        public Action<Vector2> Fire;
        public Action<Vector2> Move;
        public Action Pause;
        
        public void OnUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space)) 
                Fire?.Invoke(Vector3.up);

            if (Input.GetKeyUp(KeyCode.Escape)) 
                Pause?.Invoke();
            
            _horizontalDirection = Input.GetAxisRaw("Horizontal");
        }

        public void OnFixedUpdate()
        {
            Move?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}