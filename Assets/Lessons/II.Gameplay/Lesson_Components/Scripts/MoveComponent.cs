using System;
using UnityEngine;

namespace Lessons.Lesson_Components
{
    [Serializable]
    public class MoveComponent
    {
        public bool DebugCanMove => _debugCanMove;
        
        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private bool _debugCanMove = true;

        private ICondition _canMove = new EmptyCondition();
        private Vector3 _moveDirection;

        public void Construct(ICondition canMove)
        {
            _canMove = canMove;
        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            if (!_canMove.Invoke())
            {
                return;
            }
            
            _root.position += _moveDirection * _speed * Time.deltaTime;
        }

        public void SetDirection(Vector3 moveDirection)
        {
            _moveDirection = moveDirection;
        }
    }
}