using System.Collections;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Enemy : Unit, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        private const float StopDistance = 0.25f;
        
        [SerializeField]
        private float _countdownFire = 1f;
        
        private Pool _enemyPool;
        private ICharacter _characterController;
        private bool _isPause;
        private Coroutine _workCoroutine;

        protected override EntityType GetEntityType =>
            EntityType.Enemy;

        [Inject]
        private void Construct(Pool pool, CharacterController characterController, BulletSystem bulletSystem, LevelBounds levelBounds)
        {
            _enemyPool = pool;
            _characterController = characterController;
            
            Init(bulletSystem, levelBounds);
        }

        public void OnPauseGame()
        {
            _isPause = true;
        }

        public void OnResumeGame()
        {
            _isPause = false;
        }

        public void OnFinishGame()
        {
            _isPause = true;
        }

        public void StartWork(Vector2 destination)
        {
            _workCoroutine = StartCoroutine(AwaitWork(destination));
        }

        protected override void Die()
        {
            _enemyPool.Despawn(this);
            
            if (_workCoroutine != null)
                StopCoroutine(_workCoroutine);
        }

        private IEnumerator AwaitWork(Vector2 destination)
        {
            yield return AwaitMoveToPoint(destination);

            while (true)
                yield return AwaitAttack();
        }

        private IEnumerator AwaitMoveToPoint(Vector2 destination)
        {
            while ((destination - (Vector2)transform.position).sqrMagnitude > StopDistance)
            {
                if (_isPause)
                {
                    yield return null;
                    continue;
                }

                yield return null;
                var vector = destination - (Vector2)transform.position;
                var direction = vector.normalized * Time.fixedDeltaTime;
                Move(direction);
            }
        }

        private IEnumerator AwaitAttack()
        {
            if (_isPause)
                yield break;
            
            var direction = ((Vector2)transform.position - _characterController.GetPosition).normalized;
            Fire(direction);
            yield return new WaitForSeconds(_countdownFire);
        }
        
        public class Pool : MemoryPool<Enemy>
        {
            private readonly Transform _worldTransform;
            private readonly Transform _container;
            private readonly EnemyPositions _enemyPositions;
            private readonly GameStateController _gameStateController;

            public Pool(GameStateController gameStateController, EnemyPositions enemyPositions, Transform worldTransform, Transform container)
            {
                _gameStateController = gameStateController;
                _enemyPositions = enemyPositions;
                _worldTransform = worldTransform;
                _container = container;
            }
            
            protected override void OnCreated(Enemy item)
            {
                base.OnCreated(item);
                item.transform.SetParent(_container);
                _gameStateController.AddListener(item);
            }

            protected override void OnSpawned(Enemy item)
            {
                base.OnSpawned(item);
                item.transform.SetParent(_worldTransform);

                var spawnPosition = _enemyPositions.RandomSpawnPosition();
                item.transform.position = spawnPosition.position;
            
                var attackPosition = _enemyPositions.RandomAttackPosition();
                item.StartWork(attackPosition.position);
            }

            protected override void OnDespawned(Enemy item)
            {
                base.OnDespawned(item);
                item.transform.SetParent(_container);
            }
        }
    }
}