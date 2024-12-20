using UnityEngine;

namespace ShootEmUp
{
    public abstract class Unit : MonoBehaviour, ICrashBullet
    {
        [SerializeField]
        protected int _health = 5;

        [SerializeField]
        private MoveComponent _moveComponent;
        
        [SerializeField]
        private WeaponComponent _weaponComponent;
        
        private LevelBounds _levelBounds;

        protected abstract EntityType GetEntityType { get; }

        public void Crash(Bullet bullet)
        {
            if (bullet.GetEntityType != GetEntityType) 
                TakeDamage(bullet.GetDamage);
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;
            
            if (_health <= 0)
                Die();
        }

        protected void Init(BulletSystem bulletSystem, LevelBounds levelBounds)
        {
            _levelBounds = levelBounds;
            _weaponComponent.Init(bulletSystem);
        }

        protected void Move(Vector2 direction)
        {
            if (!_levelBounds.InBounds(transform.position + (Vector3)direction))
                return;

            _moveComponent.MoveByRigidbodyVelocity(direction);
        }

        protected abstract void Die();

        protected void Fire(Vector2 direction) => 
            _weaponComponent.OnFlyBullet(GetEntityType, direction);
    }
}