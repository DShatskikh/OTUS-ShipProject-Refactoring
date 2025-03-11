using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game
{
    public sealed class UnitEndGameOnKinematicSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag, UnitCommand, RigidbodyRoot>, Exc<DeathTag, KinematicTag>> _filter;
        private readonly EcsCustomInject<GameStateController> _gameStateController;

        private readonly EcsPoolInject<KinematicTag> _kinematicPool;
        
        public void Run(IEcsSystems systems)
        {
            if (_gameStateController.Value.GetIsPlaying)
                return;

            EcsPool<RigidbodyRoot> _rigidbodyPool = _filter.Pools.Inc3;

            foreach (var @entity in _filter.Value)
            {
                _rigidbodyPool.Get(@entity).Value.isKinematic = true;
                _kinematicPool.Value.Add(@entity);
            }
        }
    }
}