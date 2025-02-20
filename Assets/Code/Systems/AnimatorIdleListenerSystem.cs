using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class AnimatorIdleListenerSystem : IEcsRunSystem
    {
        private static readonly int AttackingHash = Animator.StringToHash("Attacking");
        private static readonly int StartHash = Animator.StringToHash("Start");

        private readonly EcsFilterInject<Inc<UnitTag>> _filter;
        private readonly EcsPoolInject<AnimatorView> _animatorPool;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        public void Run(IEcsSystems systems)
        {
            if (_gameStateController.Value.GetIsPlaying)
                return;
            
            foreach (int @event in _filter.Value)
            {
                if (_animatorPool.Value.Has(@event))
                {
                    Animator animator = _animatorPool.Value.Get(@event).Value;
                    animator.SetBool(AttackingHash, false);
                    animator.SetBool(StartHash, false);
                }
            }
        }
    }
}