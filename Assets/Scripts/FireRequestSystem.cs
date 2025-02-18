using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public class FireRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ShotRequest, BulletWeapon, Root>> _filter;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        
        public void Run(IEcsSystems systems)
        {
            EcsPool<ShotRequest> shotRequest = _filter.Pools.Inc1;
            EcsPool<BulletWeapon> firePointPool = _filter.Pools.Inc2;
            EcsPool<Root> rootPool = _filter.Pools.Inc3;

            foreach (int entity in _filter.Value)
            {
                var firePoint = firePointPool.Get(entity).FirePoint;
                var bulletPrefab = firePointPool.Get(entity).BulletPrefab;
                var root = rootPool.Get(entity).Value;

                _entityManager.Value.Create(bulletPrefab, firePoint.position, root.rotation);
                Debug.Log("Shot");

                shotRequest.Del(entity);
            }
        }
    }
}