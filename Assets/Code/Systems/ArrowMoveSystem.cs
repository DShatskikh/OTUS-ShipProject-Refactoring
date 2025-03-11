using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class ArrowMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ArrowTag, Root, MoveSpeed>, Exc<Inactive>> _filter;

        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            EcsPool<Root> transformPool = _filter.Pools.Inc2;
            EcsPool<MoveSpeed> speedPool = _filter.Pools.Inc3;
            
            foreach (int @entity in _filter.Value)
            {
                var transform = transformPool.Get(@entity).Value;
                var speed = speedPool.Get(@entity).Value;

                transform.position += transform.forward * (speed * deltaTime);
            }
        }
    }
}