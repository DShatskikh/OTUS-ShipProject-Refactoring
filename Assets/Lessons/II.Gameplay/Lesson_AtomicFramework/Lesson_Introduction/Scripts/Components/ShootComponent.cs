using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class ShootComponent
    {
        [SerializeField] private float _reloadTime = 2f;
        [SerializeField] private bool _isReloading;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        
        [ShowInInspector, ReadOnly]
        private float _reloadTimer;
        
        public CompositeCondition CanFire = new();

        public void OnUpdate(float deltaTime)
        {
            if (_isReloading)
            {
                _reloadTimer -= deltaTime;
                
                if (_reloadTimer <= 0)
                {
                    _isReloading = false;
                }
            }
        }
        
        public void Shoot()
        {
            if (!CanFire.IsTrue())
            {
                return;
            }

            if (_isReloading)
            {
                return;
            }

            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.SetDirection(_firePoint.forward);
            
            _reloadTimer = _reloadTime;
            _isReloading = true;
            
            Debug.Log("Fire!");
        }
    }
}