using System;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class TowerShootBehaviour : IEntityUpdate
    {
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private float _radius;
        
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var direction = _targetPoint.position - entity.GetTransform().position;
            entity.GetRotateDirection().Value = direction;

            if (direction.magnitude < _radius)
            {
                entity.GetShootAction().Invoke();
            }
        }
    }
}