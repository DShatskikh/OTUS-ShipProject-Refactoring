using System;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class ShootBehaviour : IEntityInit, IEntityUpdate, IEntityDispose
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        private IValue<bool> _canFire;
        private BaseEvent _shootEvent;

        void IEntityInit.Init(IEntity entity)
        {
            _canFire = entity.GetCanFire();
            entity.GetShootAction().Subscribe(Shoot);
            _shootEvent = entity.GetShootEvent();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            _timer.Tick(deltaTime);
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            entity.GetShootAction().Unsubscribe(Shoot);
        }

        public bool CanFire()
        {
            return _canFire.Value;
        }

        public void Shoot()
        {
            if (!_canFire.Value)
            {
                return;
            }

            if (_timer.IsPlaying())
            {
                return;
            }

            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.SetDirection(_firePoint.forward);

            _timer.Start();
            Debug.Log("Fire!");
            
            _shootEvent.Invoke();
        }
    }
}