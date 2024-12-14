using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class WeaponComponent
    {
        [SerializeField]
        private BulletConfig _bulletConfig;
        
        [SerializeField]
        private Transform _firePoint;

        private BulletSystem _bulletSystem;
        
        public void Init()
        {
            _bulletSystem = DIContainer.Get<BulletSystem>();
        }

        public void OnFlyBullet(EntityType entityType, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new Bullet.Data()
            {
                Config = _bulletConfig,
                Position = _firePoint.position,
                Velocity = _firePoint.rotation * direction * _bulletConfig.Speed,
                EntityType = entityType
            });
        }
    }
}