using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class CharacterController : Unit
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

        private void Awake()
        {
            _inputManager.Fire += Fire;
            _inputManager.Move += Move;
            
            Init(_bulletSystem, _bounds);
        }

        private void OnDestroy()
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