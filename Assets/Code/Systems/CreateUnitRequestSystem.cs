
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

                    // if (prefab.HasData<ArrowTag>())
                    // {
                    //     bool isSearch = false;
                    //     
                    //     //Логика поиска выключенной стрелы
                    //     foreach (var @arrowEntity in _arrowfilter.Value)
                    //     {
                    //         _inactivePool.Value.Del(@arrowEntity);
                    //
                    //         var root = _arrowfilter.Pools.Inc3.Get(@arrowEntity).Value;
                    //         root.position = spawnPoint.position;
                    //         root.rotation = spawnPoint.rotation;
                    //         root.gameObject.SetActive(true);
                    //         
                    //         pool.Del(i);
                    //         isSearch = true;
                    //         Debug.Log("Взял стрелу из пула");
                    //         continue; 
                    //     }
                    //     
                    //     if (isSearch)
                    //         continue;
                    // }
                    
                    _entityManager.Value.Create(prefab, spawnPoint.position, spawnPoint.rotation);
                    Debug.Log("Create Unit");

                    pool.Del(i);
                }
            }
        }
    }