using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class MoveToInputBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int State = Animator.StringToHash("State");
        
        private float _speed;
        private Transform _root;
        private Animator _animator;

        public void Init(IEntity entity)
        {
            _speed = entity.GetMoveSpeed();
            _root = entity.GetRoot();
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var inputDirection = entity.GetInputDirection();
            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);

            if (!entity.GetIsShot())
                _animator.SetFloat(State, direction == Vector3.zero ? 0 : 1);
            
            if (direction == Vector3.zero)
                return;

            _root.position += direction * _speed * deltaTime;
        }
    }
}