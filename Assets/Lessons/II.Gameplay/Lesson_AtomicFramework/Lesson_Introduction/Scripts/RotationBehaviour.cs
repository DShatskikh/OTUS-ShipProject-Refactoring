using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class RotationBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _rotationRoot;
        private IValue<Vector3> _rotateDirection;
        private IValue<float> _rotateRate;
        private IValue<bool> _canRotate;
        
        public void Init(IEntity entity)
        {
            _rotationRoot = entity.GetVisualTransform();
            _rotateDirection = entity.GetRotateDirection();
            _rotateRate = entity.GetRotateRate();
            _canRotate = entity.GetCanRotate();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canRotate.Value)
            {
                return;
            }

            if (_rotateDirection.Value == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection.Value, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateRate.Value);
        }
    }
}