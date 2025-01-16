using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class MovementBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _root;
        private IValue<Vector3> _moveDirection;
        private IValue<float> _speed;
        private IValue<bool> _canMove;
        
        void IEntityInit.Init(IEntity entity)
        {
            _root = entity.GetTransform();
            _moveDirection = entity.GetMoveDirection();
            _speed = entity.GetMoveSpeed();
            _canMove = entity.GetCanMove();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canMove.Value)
            {
                return;
            }
            
            _root.position += _moveDirection.Value * _speed.Value * deltaTime;
        }
    }
}