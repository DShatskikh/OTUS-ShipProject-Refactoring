using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;

namespace Game
{
    public sealed class ArrowCollisionRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<CollisionEnterRequest, ArrowTag>> _filter = EcsWorlds.EVENTS;
        private readonly EcsWorldInject _eventWorld = EcsWorlds.EVENTS;
        private readonly EcsWorldInject _world;
        private readonly EcsCustomInject<EntityManager> _entityManager;

        public void Run(IEcsSystems systems)
        {
            EcsPool<CollisionEnterRequest> sourcePool = _filter.Pools.Inc1;

            foreach (int @entity in _filter.Value)
            {
                var collision = sourcePool.Get(@entity);

                EcsStartup.Instance.CreateEntity(EcsWorlds.EVENTS)
                    .Add(new DamageRequest() { Damage = 1, Target = collision.Target });

                collision.Source.GetData<Root>().Value.gameObject.SetActive(false);
                collision.Source.AddData(new Inactive());

                _eventWorld.Value.DelEntity(@entity);
            }
        }
    }
}