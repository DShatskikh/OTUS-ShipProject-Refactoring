using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    
    [Serializable]
    public class MoveComponent
    {
        public CompositeCondition Condition = new CompositeCondition();

        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;

        private Vector3 _moveDirection;
        
        public void OnUpdate(float deltaTime)
        {
            if (!Condition.IsTrue())
            {
                return;
            }
            
            _root.position += _moveDirection * _speed * deltaTime;
        }
        
        public void SetDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }
    }
}
