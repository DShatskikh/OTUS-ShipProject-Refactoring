using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class LifeBehaviour : IEntityInit, IEntityDispose
    {
        private ReactiveInt _hitPoints;
        private ReactiveBool _isDead;
        
        void IEntityInit.Init(IEntity entity)
        {
            entity.GetTakeDamageAction().Subscribe(OnTakeDamage);
            _hitPoints = entity.GetHitPoints();
            _isDead = entity.GetIsDead();
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            entity.GetTakeDamageAction().Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            if (_isDead.Value)
            {
                return;
            }

            _hitPoints.Value -= damage;
            Debug.Log($"Take damage = {damage}");

            if (_hitPoints.Value <= 0)
            {
                _isDead.Value = true;
            }
        }
    }
}