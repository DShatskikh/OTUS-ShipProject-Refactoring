using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : Unit
    {
        private GameManager _gameManager;

        public override EntityType GetEntityType =>
            EntityType.Character;
        
        protected override void Init()
        {
            base.Init();
            _gameManager = ServiceLocator.Get<GameManager>();
        }

        //ToDo: Делаю мощный выстрел при долгом зажатии пробела
        public void ReadyFire()
        {
            
        }

        public override void Fire(Vector2 direction)
        {
            base.Fire(direction);
        }

        protected override void Die() => 
            _gameManager.FinishGame();
    }
}