using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : Unit, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameFinishListener, ICharacter
    {
        private GameStateController _gameStateController;
        private InputManager _inputManager;
        private BulletSystem _bulletSystem;
        private LevelBounds _bounds;

        protected override EntityType GetEntityType =>
            EntityType.Character;

        public Vector2 GetPosition => transform.position;
        
        [Inject]
        private void Construct(GameStateController gameStateController, InputManager inputManager,
            BulletSystem bulletSystem, LevelBounds levelBounds)
        {
            _gameStateController = gameStateController;
            _inputManager = inputManager;
            _bulletSystem = bulletSystem;
            _bounds = levelBounds;
        }
        
        public void OnStartGame()
        {
            _inputManager.Fire += Fire;
            _inputManager.Move += Move;
            
            Init(_bulletSystem, _bounds);
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
            _gameStateController.FinishGame();
        }
    }
}