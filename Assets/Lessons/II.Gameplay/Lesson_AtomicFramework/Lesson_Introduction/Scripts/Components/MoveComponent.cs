using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Vector3 _moveDirection;

        private readonly CompositeCondition _condition = new();
        
        public void OnUpdate(float deltaTime)
        {
            if (!_condition.IsTrue())
            {
                return;
            }
            
            _root.position += _moveDirection * _speed * deltaTime;
        }
        
        public void SetDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}
