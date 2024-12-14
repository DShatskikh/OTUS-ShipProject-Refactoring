using UnityEngine;

namespace ShootEmUp
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        protected int _health = 5;

        [SerializeField]
        private MoveComponent _moveComponent;
        
        [SerializeField]
        private WeaponComponent _weaponComponent;

        private LevelBounds _levelBounds;
        
        public abstract EntityType GetEntityType { get; }

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            _levelBounds = DIContainer.Get<LevelBounds>();
            _weaponComponent.Init(); 
        }
        
        protected abstract void Die();

        public void TakeDamage(int damage)
        {
            _health -= damage;
            
            if (_health <= 0)
                Die();
        }

        public virtual void Fire(Vector2 direction) => 
            _weaponComponent.OnFlyBullet(GetEntityType, direction);
        
        public void Move(Vector2 direction)
        {
            if (!_levelBounds.InBounds(transform.position + (Vector3)direction))
                return;

            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}