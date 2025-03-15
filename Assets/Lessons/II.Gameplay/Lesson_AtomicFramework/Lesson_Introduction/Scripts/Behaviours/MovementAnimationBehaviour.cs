using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class ShootAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private AnimationDispatcher _animationDispatcher;
        private IEntity _entity;
        
        void IEntityInit.Init(IEntity entity)
        {
            _entity = entity;
            _animator = entity.GetAnimator();
            _animationDispatcher = entity.GetAnimationDispatcher();
            _entity.GetShootRequest().Subscribe(OnShootAction);
            _animationDispatcher.OnEventReceived += Received;
        }

        public void Dispose(IEntity entity)
        {
            _entity.GetShootRequest().Unsubscribe(OnShootAction);
            _animationDispatcher.OnEventReceived -= Received;
        }

        private void Received(string eventName)
        {
            if (eventName == "shoot")
            {
                _entity.GetShootAction().Invoke();
            }
        }

        private void OnShootAction()
        {
            _animator.SetTrigger("Shoot");
            //сам ивент стрельбы ShootAction() вызывает event в анимации
        }
    }

    public class MovementAnimationBehaviour : IEntityInit
    {
        private Animator _animator;
        private static readonly int s_isMoving = Animator.StringToHash("IsMoving");

        void IEntityInit.Init(IEntity entity)
        {
            entity.GetMoveDirection().Subscribe(OnMoveDirectionChanged);
            _animator = entity.GetAnimator();
        }

        private void OnMoveDirectionChanged(Vector3 moveDirection)
        {
            var isMoving = moveDirection.sqrMagnitude > 0;
            _animator.SetBool(s_isMoving, isMoving);
        }
    }
}