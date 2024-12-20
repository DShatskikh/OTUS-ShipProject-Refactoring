using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private float _spawnInterval = 1f;
        
        public void StartSpawn()
        {
            StartCoroutine(AwaitSpawn());
        }

        private IEnumerator AwaitSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                _enemyPool.TrySpawnEnemy(out Enemy enemy);
            }
        }
    }
}