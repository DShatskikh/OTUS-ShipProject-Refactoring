using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : Unit, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        [SerializeField]
        private GameStateController _gameStateController;

        [SerializeField]
        private InputManager _inputManager;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private LevelBounds _bounds;

        protected override EntityType GetEntityType =>
            EntityType.Character;

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