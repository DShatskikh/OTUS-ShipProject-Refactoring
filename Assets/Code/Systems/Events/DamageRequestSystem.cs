using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Game
{
    public sealed class DamageRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageRequest>> _filter = EcsWorlds.EVENTS;
        private readonly EcsWorldInject _eventWorld = EcsWorlds.EVENTS;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        public void Run(IEcsSystems systems)
        {
            EcsPool<DamageRequest> damageRequestPool = _filter.Pools.Inc1;

            foreach (int @entity in _filter.Value)
            {
                var damageRequest = damageRequestPool.Get(@entity);
                var targetEntity = damageRequest.Target;
                ref var health = ref damageRequest.Target.GetData<Health>();

                if (health.Current <= 0)
                {
                    _eventWorld.Value.DelEntity(@entity);
                    continue;
                }

                health.Current -= damageRequest.Damage;

                if (targetEntity.HasData<DamageParticle>())
                    targetEntity.GetData<DamageParticle>().Value.Play();
                
                if (health.Current <= 0)
                {
                    health.Current = 0;
                    
                    if (!targetEntity.HasData<DeathTag>())
                        targetEntity.AddData(new DeathTag());

                    if (targetEntity.HasData<BaseTag>())
                        _gameStateController.Value.EndGame();   
                }

                _eventWorld.Value.DelEntity(@entity);
            }
        }
    }
}