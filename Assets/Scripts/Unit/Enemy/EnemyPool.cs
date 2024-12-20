using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;
        
        [SerializeField]
        private Transform _worldTransform;
        
        [Header("Pool")]
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private Enemy _prefab;

        [SerializeField]
        private int _poolSize = 7;

        [Header("Enemy")]
        [SerializeField]
        private CharacterController _characterController;
        
        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private LevelBounds _levelBounds;
        
        private readonly Queue<Enemy> _enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < _poolSize; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                enemy.Init(this, _characterController, _bulletSystem, _levelBounds);
                _enemyPool.Enqueue(enemy);
            }
        }

        public bool TrySpawnEnemy(out Enemy enemy)
        {
            enemy = null;
            
            if (!_enemyPool.TryDequeue(out var result))
                return false;

            result.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            result.transform.position = spawnPosition.position;
            
            var attackPosition = _enemyPositions.RandomAttackPosition();
            result.StartWork(attackPosition.position);
            enemy = result;
            return true;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}