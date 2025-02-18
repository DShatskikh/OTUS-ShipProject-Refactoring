using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public class BulletMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Bullet, Root, MoveSpeed>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
             
            EcsPool<Root> rootPool = _filter.Pools.Inc2;
            EcsPool<MoveSpeed> movePool = _filter.Pools.Inc3;
            
            foreach (int entity in _filter.Value)
            {
                var transform = rootPool.Get(entity).Value;
                var move = movePool.Get(entity).Value;

                transform.position += transform.forward * move * deltaTime;
            }
        }
    }
}