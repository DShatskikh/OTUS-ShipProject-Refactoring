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

        private readonly Queue<Enemy> _enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public Enemy SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
                return null;

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.StartAttack(attackPosition.position);
            return enemy;
        }

        public void UnspawnEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}