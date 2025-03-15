using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class LifeInstaller : IEntityInstaller
    {
        [SerializeField] private int _hitPoints = 3;
        [SerializeField] private bool _isDead;
        
        public void Install(IEntity entity)
        {
            entity.AddHitPoints(new ReactiveInt(_hitPoints));
            entity.AddIsDead(new ReactiveBool(_isDead));
            entity.AddTakeDamageAction(new AtomicEvent<int>());

            entity.AddBehaviour(new LifeBehaviour());
        }
    }
}