using System;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class KeyboardInput : MonoBehaviour, IGameUpdateListener
    {
        public event Action<Vector2> OnMoveInputChanged;
        public event Action<Vector2> OnCameraInputChanged; 

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector2.right);
            }
            else
            {
                Move(Vector2.zero);
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                CameraMove(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                CameraMove(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CameraMove(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CameraMove(Vector2.right);
            }
            else
            {
                CameraMove(Vector2.zero);
            }
        }

        private void CameraMove(Vector2 direction)
        {
            OnCameraInputChanged?.Invoke(direction);
        }

        private void Move(Vector2 direction)
        {
            OnMoveInputChanged?.Invoke(direction);
        }
    }
}