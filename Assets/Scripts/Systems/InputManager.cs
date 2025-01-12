using System;
using GameCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IGameTickableListener, IGameFixedUpdateListener
    {
        private float _horizontalDirection;

        public Action<Vector2> Fire;
        public Action<Vector2> Move;
        
        public void Tick(float delta)
        {
            if (Input.GetKeyUp(KeyCode.Space)) 
                Fire?.Invoke(Vector3.up);
            
            _horizontalDirection = Input.GetAxisRaw("Horizontal");
        }

        public void FixedTick(float delta)
        {
            Move?.Invoke(new Vector2(_horizontalDirection, 0) * delta);
        }
    }
}