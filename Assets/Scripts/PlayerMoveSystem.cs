using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InputDirection, Root, MoveSpeed>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
             
            EcsPool<InputDirection> inputPool = _filter.Pools.Inc1;
            EcsPool<Root> rootPool = _filter.Pools.Inc2;
            EcsPool<MoveSpeed> movePool = _filter.Pools.Inc3;
            
            foreach (int entity in _filter.Value)
            {
                var transform = rootPool.Get(entity).Value;
                var input = inputPool.Get(entity).Value;
                var move = movePool.Get(entity).Value;

                transform.position += new Vector3(input.x, 0, input.y) * move * deltaTime;
            }
        }
    }
}