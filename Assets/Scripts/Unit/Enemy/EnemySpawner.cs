using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private float _spawnInterval = 1f;

        [SerializeField]
        private GameStateController _gameStateController;
        
        private float _currentSpawnCounter;

        public void OnUpdate()
        {
            _currentSpawnCounter += Time.deltaTime;

            if (_currentSpawnCounter >= _spawnInterval)
            {
                _currentSpawnCounter = 0;
                _enemyPool.TrySpawnEnemy(out Enemy enemy);
                _gameStateController.AddListener(enemy);
            }
        }
    }
}