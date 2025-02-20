using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class UnitArcherAttackSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, AttackTarget, AttackState, Cooldown, ArrowPrefab, BowPoint, UnitCommand, ArcherTag>, Exc<DeathTag>> _filter;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            var deltaTime = Time.deltaTime;

            EcsPool<AttackTarget> attackPool = _filter.Pools.Inc2;
            EcsPool<Cooldown> cooldownPool = _filter.Pools.Inc4;
            EcsPool<ArrowPrefab> prefabPool = _filter.Pools.Inc5;
            EcsPool<BowPoint> bowPointPool = _filter.Pools.Inc6;
            EcsPool<UnitCommand> unitCommandPool = _filter.Pools.Inc7;

            foreach (int @entity in _filter.Value)
            {
                var attack = attackPool.Get(@entity).Value;
                ref var cooldown = ref cooldownPool.Get(@entity);
                var prefab = prefabPool.Get(@entity).Value;
                var bowPoint = bowPointPool.Get(@entity).Value;
                var command = unitCommandPool.Get(@entity).Value;

                cooldown.Current += deltaTime;

                if (cooldown.Current > cooldown.Max)
                {
                    Debug.Log("Атакую башню!!!");
                    var arrow = _entityManager.Value.Create(prefab, bowPoint.position, bowPoint.rotation);
                    arrow.AddData(new UnitCommand() { Value = command });
                    cooldown.Current = 0;
                }
            }
        }
    }
}