using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class MoveController : MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private KeyboardInput _input;

        private bool _enabled;

        [Button]
        void IGameStartListener.OnStartGame()
        {
            _input.OnMoveInputChanged += OnMoveInputChanged;
            _enabled = true;
        }

        void IGameFinishListener.OnFinishGame()
        {
            _input.OnMoveInputChanged -= OnMoveInputChanged;
        }

        void IGamePauseListener.OnPauseGame()
        {
            _enabled = false;
        }

        void IGameResumeListener.OnResumeGame()
        {
            _enabled = true;
        }

        private void OnMoveInputChanged(Vector2 direction)
        {
            if (!_enabled)
            {
                return;
            }
            
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            _player.Move(offset);
        }
    }
}