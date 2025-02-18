using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public class RotateToSeePointSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Root, SeePoint, RotationSpeed>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            EcsPool<Root> rootPool = _filter.Pools.Inc1;
            EcsPool<SeePoint> seePointPool = _filter.Pools.Inc2;
            EcsPool<RotationSpeed> rotationSpeedPool = _filter.Pools.Inc3;
            
            foreach (int entity in _filter.Value)
            {
                var transform = rootPool.Get(entity).Value;
                var seePoint = seePointPool.Get(entity).Value;
                var rotationSpeed = rotationSpeedPool.Get(entity).Value;

                var direction = Vector3.Normalize(new Vector3(seePoint.x, 0, seePoint.y) - transform.position);
                var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}