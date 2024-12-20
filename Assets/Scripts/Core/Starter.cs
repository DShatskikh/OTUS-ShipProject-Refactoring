using UnityEngine;

namespace ShootEmUp
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner _enemySpawner;
        
        private void Start()
        {
            _enemySpawner.StartSpawn();
        }
    }
}