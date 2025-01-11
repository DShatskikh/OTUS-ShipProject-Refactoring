using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemySystemInstaller : MonoInstaller
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;
        
        [SerializeField]
        private Transform _worldTransform;
        
        [SerializeField]
        private float _spawnInterval = 1f;

        [SerializeField]
        private Enemy _prefab;
        
        [Header("Pool")]
        [SerializeField]
        private Transform _container;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Enemy,Enemy.Pool>()
                .WithInitialSize(5)
                .WithFactoryArguments(_enemyPositions, _worldTransform, _container)
                .FromComponentInNewPrefab(_prefab)
                .AsCached();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(_spawnInterval);
        }
    }
}