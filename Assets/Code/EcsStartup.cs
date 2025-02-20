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
        private EcsWorld _events;
        private IEcsSystems _systems;
        private EntityManager _entityManager;
        private GameStateController _gameStateController;
        public GameStateController GameStateController => _gameStateController;
        private static EcsStartup _instance;

        public static EcsStartup Instance => _instance;
        
        private void Awake()
        {
            _instance = this;
            
            _entityManager = new EntityManager();
            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems.AddWorld(_events, EcsWorlds.EVENTS);
            _systems
                //.Add(new PlayerMoveSystem())
                //.Add(new RotateToSeePointSystem())
                //.Add(new FireRequestSystem())
                //.Add(new BulletMoveSystem())
                .Add(new CreateUnitRequestSystem())
                .Add(new UnitSearchAttackTargetSystem())
                .Add(new UnitSwitchMoveStateToDistanceSystem())
                .Add(new UnitMoveToAttackTargetSystem())
                .Add(new UnitRotateToAttackTargetSystem())
                .Add(new UnitArcherAttackSystem())
                .Add(new ArrowMoveSystem())
                .Add(new UnitKnightAttackSystem())
                .Add(new AnimatorAttackListenerSystem())
                .Add(new AnimatorMoveListenerSystem())
                .Add(new AnimatorIdleListenerSystem())
                .Add(new ArrowCollisionRequestSystem())
                .Add(new DamageRequestSystem())
                .Add(new UnitDestroyDeathSystem())

#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                ;
#endif
        }

        private void Start()
        {
            _gameStateController = new GameStateController();
            
            _entityManager.Initialize(_world);
            PhysicsWorld.Initialize(_events);
            _systems.Inject(_entityManager);
            _systems.Inject(_gameStateController);
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
        
        public EcsEntityBuilder CreateEntity(string worldName = null) => 
            new(_systems.GetWorld(worldName));
    }
}