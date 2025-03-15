using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class MovementBehaviour : IEntityInit, IEntityUpdate
    {
        // public CompositeCondition Condition = new CompositeCondition();

        private Transform _root;
        private IReactiveVariable<Vector3> _moveDirection;
        private IReactiveVariable<float> _moveSpeed;

        void IEntityInit.Init(IEntity entity)
        {
            _root = entity.GetRoot();
            _moveDirection = entity.GetMoveDirection();
            _moveSpeed = entity.GetMoveSpeed();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            _root.position += _moveDirection.Value * _moveSpeed.Value * deltaTime;
        }
    }
}