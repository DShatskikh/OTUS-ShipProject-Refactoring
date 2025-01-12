using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public abstract class Unit : MonoBehaviour, ICrashBullet
    {
        private int _health = 5;
        private MoveComponent _moveComponent;
        private WeaponComponent _weaponComponent;
        private LevelBounds _levelBounds;

        protected abstract EntityType GetEntityType { get; }

        [Inject]
        private void Init(LevelBounds levelBounds, MoveComponent moveComponent, WeaponComponent weaponComponent, IUnitConfig unitConfig)
        {
            _levelBounds = levelBounds;
            _moveComponent = moveComponent;
            _health = unitConfig.Health;
            _weaponComponent = weaponComponent;
        }

        public void Crash(Bullet bullet)
        {
            if (bullet.GetEntityType != GetEntityType) 
                TakeDamage(bullet.GetDamage);
        }

        protected void Move(Vector2 direction)
        {
            if (!_levelBounds.InBounds(transform.position + (Vector3)direction))
                return;

            _moveComponent.MoveByRigidbodyVelocity(direction);
        }

        protected void Fire(Vector2 direction) => 
            _weaponComponent.OnFlyBullet(GetEntityType, direction);

        protected abstract void Die();

        private void TakeDamage(int damage)
        {
            _health -= damage;
            
            if (_health <= 0)
                Die();
        }
    }
}