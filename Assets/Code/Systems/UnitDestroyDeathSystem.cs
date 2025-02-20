using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;

namespace Game
{
    public sealed class UnitDestroyDeathSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, DeathTag>> _filter;
        private readonly EcsWorldInject _world;
        private readonly EcsCustomInject<EntityManager> _entityManager;

        public void Run(IEcsSystems systems)
        {
            foreach (int @entity in _filter.Value)
            {
                _entityManager.Value.Destroy(@entity);
            }
        }
    }
}