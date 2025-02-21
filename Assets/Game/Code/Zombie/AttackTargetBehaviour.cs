using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class AttackTargetBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int State = Animator.StringToHash("State");
        
        private Animator _animator;
        private Transform _target;
        private Transform _root;

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _target = entity.GetTarget();
            _root = entity.GetRoot();
            var animatorDispatcher = entity.GetAnimatorDispatcher();
            
            animatorDispatcher.SubscribeOnEvent("Shot", () =>
            {
                _target.GetComponent<SceneEntity>().Entity.GetDamageRequest()?.Invoke(1);
            });
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var distance = Vector2.Distance(_target.position, _root.position);
            
            if (distance < 0.5f)
            {
                _animator.SetFloat(State, 2);
            }
            else
            {
                _animator.SetFloat(State, 1);
            }
        }
    }
}