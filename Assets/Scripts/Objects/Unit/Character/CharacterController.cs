using System;
using GameCycle;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : Unit, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameFinishListener, ICharacter
    {
        private GameStateController _gameStateController;
        private InputManager _inputManager;

        protected override EntityType GetEntityType =>
            EntityType.Character;

        public Vector2 GetPosition => transform.position;
        public event Action OnDeath;

        [Inject]
        private void Construct(GameStateController gameStateController, InputManager inputManager)
        {
            _gameStateController = gameStateController;
            _inputManager = inputManager;
        }
        
        public void OnStartGame()
        {
            _inputManager.Fire += Fire;
            _inputManager.Move += Move;
        }

        public void OnPauseGame()
        {
            _inputManager.Fire -= Fire;
            _inputManager.Move -= Move;
        }

        public void OnResumeGame()
        {
            _inputManager.Fire += Fire;
            _inputManager.Move += Move;
        }

        public void OnFinishGame()
        {
            _inputManager.Fire -= Fire;
            _inputManager.Move -= Move;
        }

        protected override void Die()
        {
            OnDeath?.Invoke();
        }
    }
}