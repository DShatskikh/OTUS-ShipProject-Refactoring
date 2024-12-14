﻿using UnityEngine;

namespace ShootEmUp
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField]
        private LevelBounds _levelBounds;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private EnemySpawner _enemySpawner;

        [SerializeField]
        private EnemyPool _enemyPool;
        
        private readonly GameManager _gameManager = new();

        private void Awake()
        {
            Register();
        }

        private void Start()
        {
            _enemySpawner.StartSpawn();
        }

        private void Register()
        {
            DIContainer.Register(_characterController);
            DIContainer.Register(_gameManager);
            DIContainer.Register(_levelBounds);
            DIContainer.Register(_bulletSystem);
            DIContainer.Register(_enemyPool);
        }
    }
}