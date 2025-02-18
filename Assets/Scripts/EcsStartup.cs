using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.PhysicsExtensions;
using UnityEngine;

namespace Game
{
    public class EcsStartup : MonoBehaviour 
    {
        private EcsWorld _world;
        //private EcsWorld _events;
        private IEcsSystems _systems;
        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new EntityManager();
            _world = new EcsWorld();
            _systems = new EcsSystems (_world);
            _systems
                .Add(new PlayerMoveSystem())
                .Add(new RotateToSeePointSystem())
                .Add(new FireRequestSystem())
                .Add(new BulletMoveSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                ;
#endif
        }

        private void Start() 
        {
            _entityManager.Initialize(_world);
            PhysicsWorld.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        private void Update() 
        {
            _systems?.Run();
        }

        private void OnDestroy() 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) 
            {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}