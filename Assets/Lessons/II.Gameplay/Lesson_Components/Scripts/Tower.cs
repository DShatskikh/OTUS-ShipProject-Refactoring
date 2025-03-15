using System;
using UnityEngine;

namespace Lessons.Lesson_Components
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private RotateComponent _rotateComponent;

        [SerializeField] private Transform _target;

        private void Awake()
        {
            _rotateComponent.CanRotate.AppendCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            var rotationDirection = _target.position - _rotateComponent.RotationRoot.position;
            rotationDirection.Normalize();
            _rotateComponent.SetRotationDirection(rotationDirection);
        }
    }
}