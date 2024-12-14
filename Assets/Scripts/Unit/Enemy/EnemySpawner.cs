using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        public void StartSpawn()
        {
            StartCoroutine(AwaitSpawn());
        }

        private IEnumerator AwaitSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _enemyPool.SpawnEnemy();
            }
        }
    }
}