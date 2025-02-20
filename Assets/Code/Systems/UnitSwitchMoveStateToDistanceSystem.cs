using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class UnitSwitchMoveStateToDistanceSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, AttackTarget, AttackRadius, Root, AttackState>, Exc<DeathTag>> _filter;
        private readonly EcsPoolInject<MoveState> _movePool;
        private readonly EcsCustomInject<GameStateController> _gameStateController;
        
        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            EcsPool<Root> transformPool = _filter.Pools.Inc4;
            EcsPool<AttackTarget> targetPool = _filter.Pools.Inc2;
            EcsPool<AttackRadius> radiusPool = _filter.Pools.Inc3;
            EcsPool<AttackState> attackStatePool = _filter.Pools.Inc5;

            foreach (int @entity in _filter.Value)
            {
                var transform = transformPool.Get(@entity).Value;
                var target = targetPool.Get(@entity).Value;
                var radius = radiusPool.Get(@entity).Value;

                if (Vector3.Distance(transform.position, target.position) > radius)
                {
                    attackStatePool.Del(@entity);
                    _movePool.Value.Add(@entity);
                }
            }
        }
    }
}