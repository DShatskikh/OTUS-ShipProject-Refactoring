using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class AnimatorMoveListenerSystem : IEcsRunSystem
    {
        private static readonly int AttackingHash = Animator.StringToHash("Attacking");

        private readonly EcsFilterInject<Inc<MoveState, UnitTag>> _filter;
        
        private readonly EcsPoolInject<AnimatorView> _animatorPool;

        public void Run(IEcsSystems systems)
        {
            foreach (int @event in _filter.Value)
            {
                if (_animatorPool.Value.Has(@event))
                {
                    Animator animator = _animatorPool.Value.Get(@event).Value;
                    animator.SetBool(AttackingHash, false);
                }
            }
        }
    }
}
