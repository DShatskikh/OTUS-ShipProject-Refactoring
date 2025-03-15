using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class ShootInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private ShootBehaviour _shootBehaviour;

        public void Install(IEntity entity)
        {
            entity.AddFirePoint(_firePoint);
            
            entity.AddShootRequest(new AtomicEvent());
            entity.AddShootAction(new AtomicEvent());
            entity.AddBehaviour(_shootBehaviour);
        }
    }
}