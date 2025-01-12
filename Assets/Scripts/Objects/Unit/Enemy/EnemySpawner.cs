using System;
using GameCycle;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemySpawner : IGameTickableListener
    {
        private const int MaxEnemy = 5;
        
        private readonly float _spawnInterval = 1f;
        private readonly Enemy.Pool _enemyPool;
        private float _currentSpawnCounter;

        private EnemySpawner(Enemy.Pool enemyPool, float spawnInterval)
        {
            _enemyPool = enemyPool;
            _spawnInterval = spawnInterval;
        }

        public void Tick(float delta)
        {
            if (_enemyPool.NumActive > MaxEnemy)
                return;
            
            _currentSpawnCounter += delta;

            if (_currentSpawnCounter >= _spawnInterval)
            {
                _currentSpawnCounter = 0;
                _enemyPool.Spawn();
            }
        }
    }
}