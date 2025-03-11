using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class OrcBaseInstaller : EntityInstaller
    {
        [SerializeField]
        private Entity _archerPrefab;

        [SerializeField]
        private Entity _knightPrefab;
        
        [SerializeField]
        private Transform[] _spawnPoints;
        
        [SerializeField]
        private int _health = 10;
        
        [SerializeField]
        private ParticleSystem _damageParticle;

        private Entity _entity;
        private GameStateController _gameStateController;

        protected override void Install(Entity entity)
        {
            _gameStateController = EcsStartup.Instance.GameStateController;
            _entity = entity;
            
            entity.AddData(new BaseTag());
            entity.AddData(new EntityRoot() { Value = entity });
            entity.AddData(new UnitCommand() { Value = UnitCommandType.Orc});
            entity.AddData(new Root() {Value = transform});
            entity.AddData(new Health() {Current = _health, Max = _health});
            entity.AddData(new DamageParticle { Value = _damageParticle });
        }

        protected override void Dispose(Entity entity)
        {
            
        }

        private void Update()
        {
            if (!_gameStateController.GetIsPlaying)
                return;
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _entity.AddData(new CreateUnitRequest()
                {
                    Prefab = _archerPrefab,
                    SpawnPoint = GetSpawnPoint()
                });
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                _entity.AddData(new CreateUnitRequest()
                {
                    Prefab = _knightPrefab,
                    SpawnPoint = GetSpawnPoint()
                });
            }
        }

        private Transform GetSpawnPoint() => 
            _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}