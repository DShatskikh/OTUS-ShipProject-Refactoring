using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class UnitKnightAttackSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, AttackTarget, AttackState, Cooldown, UnitCommand, KnightTag, Sword>, Exc<DeathTag>> _filter;
        private readonly EcsCustomInject<GameStateController> _gameStateController;
        private readonly EcsWorldInject _eventWorld = EcsWorlds.EVENTS;
        
        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            var deltaTime = Time.deltaTime;

            EcsPool<AttackTarget> attackPool = _filter.Pools.Inc2;
            EcsPool<Cooldown> cooldownPool = _filter.Pools.Inc4;
            EcsPool<UnitCommand> unitCommandPool = _filter.Pools.Inc5;
            EcsPool<Sword> swordPool = _filter.Pools.Inc7;

            foreach (int @entity in _filter.Value)
            {
                var attack = attackPool.Get(@entity).Value;
                ref var cooldown = ref cooldownPool.Get(@entity);
                var command = unitCommandPool.Get(@entity).Value;
                var sword = swordPool.Get(@entity).Value;

                cooldown.Current += deltaTime;

                if (cooldown.Current > cooldown.Max)
                {
                    Debug.Log("Атакую мечом!!!");
                    var damage = sword.GetData<Damage>().Value;

                    EcsStartup.Instance.CreateEntity(EcsWorlds.EVENTS)
                        .Add(new DamageRequest() { Damage = damage, Target = attack.GetComponent<Entity>() });
                    
                    cooldown.Current = 0;
                }
            }
        }
    }
}