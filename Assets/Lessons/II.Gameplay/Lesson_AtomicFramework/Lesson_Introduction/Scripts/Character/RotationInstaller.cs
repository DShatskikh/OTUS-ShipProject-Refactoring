using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class RotationInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _visualRoot;
        [SerializeField] private ReactiveVariable<float> _rotateRate;
        
        public void Install(IEntity entity)
        {
            entity.AddRotateDirection(new ReactiveVariable<Vector3>());
            entity.AddRotateSpeed(_rotateRate);
            entity.AddVIsualRoot(_visualRoot);
            
            entity.AddBehaviour(new RotateBehaviour());
        }
    }
}