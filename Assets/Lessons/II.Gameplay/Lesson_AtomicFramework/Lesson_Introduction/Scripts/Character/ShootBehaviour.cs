using System;
using Atomic.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class ShootBehaviour : IEntityInit
    {
        [SerializeField] private Bullet _bulletPrefab;
        private Transform _firePoint;

        void IEntityInit.Init(IEntity entity)
        {
            var shootAction = entity.GetShootAction();
            shootAction.Subscribe(Shoot);
            _firePoint = entity.GetFirePoint();
        }

        public void Shoot()
        {
            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.SetDirection(_firePoint.forward);
            
            Debug.Log("Fire!");
        }
    }
    
    [Serializable]
    public class ShootVfxBehaviour : IEntityInit
    {
        [SerializeField] private ParticleSystem _shootVfx;
        
        private Transform _firePoint;

        void IEntityInit.Init(IEntity entity)
        {
            _firePoint = entity.GetFirePoint();
            
            entity.GetShootAction().Subscribe(OnShoot);
        }

        private void OnShoot()
        {
            _shootVfx.transform.position = _firePoint.position;
            _shootVfx.Play();
        }
    }
}