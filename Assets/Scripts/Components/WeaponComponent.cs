using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class WeaponComponent
    {
        private BulletConfig _bulletConfig;
        private Transform _firePoint;
        private BulletSystem _bulletSystem;

        [Inject]
        public WeaponComponent(BulletSystem bulletSystem, Transform firePoint, IUnitConfig unitConfig)
        {
            _bulletSystem = bulletSystem;
            _bulletConfig = unitConfig.BulletConfig;
            _firePoint = firePoint;
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