using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class RotationComponent
    {
        public CompositeCondition Condition = new();

        [SerializeField] private Transform _rotationRoot;
        [SerializeField] private Vector3 _rotateDirection;
        [SerializeField] private float _rotateRate;
        
        public void Rotate(Vector3 forwardDirection)
        {
            _rotateDirection = forwardDirection;

            if (!Condition.IsTrue())
            {
                return;
            }

            if (forwardDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateRate);
        }
    }
}