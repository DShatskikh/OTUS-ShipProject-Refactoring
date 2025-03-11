using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class UnitRotateToAttackTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, AttackTarget, RotationSpeed, Root>, Exc<DeathTag>> _filter;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        public void Run(IEcsSystems systems)
        {
            if (!_gameStateController.Value.GetIsPlaying)
                return;
            
            float deltaTime = Time.deltaTime;

            EcsPool<Root> rootPool = _filter.Pools.Inc4;
            EcsPool<AttackTarget> targetPool = _filter.Pools.Inc2;
            EcsPool<RotationSpeed> speedPool = _filter.Pools.Inc3;

            foreach (int entity in _filter.Value)
            {
                var transform = rootPool.Get(entity).Value;
                var target = targetPool.Get(entity).Value.transform;
                var rotationSpeed = speedPool.Get(entity).Value;

                var direction = Vector3.Normalize(target.position - transform.position);
                var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * deltaTime);
            }
        }
    }
}