
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.Di;
    using Leopotam.EcsLite.Entities;
    using UnityEngine;

    namespace Game
    {
        public class CreateUnitRequestSystem : IEcsRunSystem
        {
            private readonly EcsFilterInject<Inc<CreateUnitRequest>> _filter;
            private readonly EcsFilterInject<Inc<ArrowTag, Inactive, Root>> _arrowfilter;
            private readonly EcsCustomInject<EntityManager> _entityManager;

            private readonly EcsPoolInject<Inactive> _inactivePool;
            
            public void Run(IEcsSystems systems)
            {
                EcsPool<CreateUnitRequest> pool = _filter.Pools.Inc1;

                foreach (int i in _filter.Value)
                {
                    var spawnPoint = pool.Get(i).SpawnPoint;
                    var prefab = pool.Get(i).Prefab;

                    _entityManager.Value.Get(prefab, spawnPoint.position, spawnPoint.rotation, true);
                    Debug.Log("Create Unit");

                    pool.Del(i);
                }
            }
        }
    }