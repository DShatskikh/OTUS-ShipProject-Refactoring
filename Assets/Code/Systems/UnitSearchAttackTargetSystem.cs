using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class UnitSearchAttackTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, UnitCommand, EntityRoot>, Exc<DeathTag>> _filter;
        private readonly EcsFilterInject<Inc<BaseTag, UnitCommand, EntityRoot>> _baseFilter;
        
        private readonly EcsPoolInject<AttackTarget> _positionAttackTarget;
        private readonly EcsCustomInject<GameStateController> _gameStateController;
        
        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            EcsPool<EntityRoot> rootPool = _filter.Pools.Inc3;
            EcsPool<UnitCommand> unitCommand = _filter.Pools.Inc2;
            
            foreach (int @event in _filter.Value)
            {
                var entity = rootPool.Get(@event).Value;
                var minDistance = float.MaxValue;
                Entity nearestTarget = null;

                foreach (int i in _filter.Value)
                {
                    var targetEntity = rootPool.Get(i).Value;
                    var distance = Vector3.Distance(entity.transform.position, targetEntity.transform.position);
                    
                    if (distance < minDistance && unitCommand.Get(i).Value != unitCommand.Get(@event).Value)
                    {
                        minDistance = distance;
                        nearestTarget = targetEntity;
                    }
                }

                foreach (int @baseEvent in _baseFilter.Value)
                {
                    EcsPool<EntityRoot> baseRootPool = _baseFilter.Pools.Inc3;
                    EcsPool<UnitCommand> baseUnitCommand = _baseFilter.Pools.Inc2;

                    if (baseUnitCommand.Get(@baseEvent).Value != unitCommand.Get(@event).Value)
                    {
                        if (!nearestTarget)
                        {
                            nearestTarget = baseRootPool.Get(@baseEvent).Value;
                        }
                        else
                        {
                            var distance = Vector3.Distance(entity.transform.position, baseRootPool.Get(@baseEvent).Value.transform.position);

                            if (distance < minDistance) 
                                nearestTarget = baseRootPool.Get(@baseEvent).Value;
                        }
                    }
                }

                if (nearestTarget)
                {
                    if (_positionAttackTarget.Value.Has(@event))
                    {
                        _positionAttackTarget.Value.Get(@event) = new AttackTarget() { Value = nearestTarget };
                    }
                    else
                    {
                        _positionAttackTarget.Value.Add(@event) = new AttackTarget() { Value = nearestTarget };
                    }
                }
            }
        }
    }
}