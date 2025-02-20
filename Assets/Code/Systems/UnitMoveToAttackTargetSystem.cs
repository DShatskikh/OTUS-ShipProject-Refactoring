using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class UnitMoveToAttackTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, AttackTarget, MoveSpeed, AttackRadius, Root, MoveState>, Exc<DeathTag>> _filter;
        private readonly EcsPoolInject<AttackState> _attackPool;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            var deltaTime = Time.deltaTime;

            EcsPool<Root> transformPool = _filter.Pools.Inc5;
            EcsPool<AttackTarget> targetPool = _filter.Pools.Inc2;
            EcsPool<AttackRadius> radiusPool = _filter.Pools.Inc4;
            EcsPool<MoveSpeed> speedPool = _filter.Pools.Inc3;
            EcsPool<MoveState> moveStatePool = _filter.Pools.Inc6;

            foreach (int @entity in _filter.Value)
            {
                var transform = transformPool.Get(@entity).Value;
                var target = targetPool.Get(@entity).Value;
                var speed = speedPool.Get(@entity).Value;
                var radius = radiusPool.Get(@entity).Value;

                if (Vector3.Distance(transform.position, target.position) <= radius)
                {
                    moveStatePool.Del(@entity);
                    _attackPool.Value.Add(@entity);
                    continue;
                }

                var direction = Vector3.Normalize(target.position - transform.position);
                transform.position += new Vector3(direction.x, 0, direction.y) * speed * deltaTime;
            }
        }
    }
}