using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class MoveToTargetBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int State = Animator.StringToHash("State");
        
        private float _speed;
        private Transform _root;
        private Animator _animator;
        private Transform _target;

        public void Init(IEntity entity)
        {
            _speed = entity.GetMoveSpeed();
            _root = entity.GetRoot();
            _target = entity.GetTarget();
            _animator = entity.GetAnimator();
            
            _animator.SetFloat(State, 1);
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var direction = (_target.position - _root.position).normalized;
            _root.position += direction * _speed * deltaTime;
        }
    }
}