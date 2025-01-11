using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemySpawner : IGameUpdateListener
    {
        private readonly float _spawnInterval = 1f;
        private readonly Enemy.Pool _enemyPool;
        private float _currentSpawnCounter;

        private EnemySpawner(Enemy.Pool enemyPool, float spawnInterval)
        {
            _enemyPool = enemyPool;
            _spawnInterval = spawnInterval;
        }

        public void OnUpdate()
        {
            _currentSpawnCounter += Time.deltaTime;

            if (_currentSpawnCounter >= _spawnInterval)
            {
                _currentSpawnCounter = 0;
                _enemyPool.Spawn();
            }
        }
    }
}