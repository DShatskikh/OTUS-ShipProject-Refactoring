using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class CameraController : MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener, 
        IGameUpdateListener
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed = 4f;
        [SerializeField] private KeyboardInput _keyboardInput;

        private Vector3 _direction;

        [Button]
        void IGameStartListener.OnStartGame()
        {
            _keyboardInput.OnCameraInputChanged += OnCameraInputChanged;
        }

        void IGameFinishListener.OnFinishGame()
        {
            _keyboardInput.OnCameraInputChanged -= OnCameraInputChanged;
        }

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
            _camera.transform.position += _direction * _speed * deltaTime;
        }

        private void OnCameraInputChanged(Vector2 direction)
        {
            _direction = new Vector3(direction.x, 0f, direction.y);
        }
    }
}