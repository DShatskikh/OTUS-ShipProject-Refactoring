using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class RotateBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _rotationRoot;
        private IReactiveVariable<float> _rotateRate;
        private IReactiveVariable<Vector3> _rotateDirection;
        
        void IEntityInit.Init(IEntity entity)
        {
            _rotateDirection = entity.GetRotateDirection();
            _rotationRoot = entity.GetVIsualRoot();
            _rotateRate = entity.GetRotateSpeed();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            // if (!Condition.IsTrue())
            // {
            //     return;
            // }

            if (_rotateDirection.Value == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection.Value, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateRate.Value);
        }
    }
}