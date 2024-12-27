using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Unit, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        private const float StopDistance = 0.25f;
        
        [SerializeField]
        private float _countdownFire = 1f;
        
        private EnemyPool _enemyPool;
        private CharacterController _characterController;
        private bool _isPause;
        private Coroutine _workCoroutine;

        protected override EntityType GetEntityType =>
            EntityType.Enemy;

        public void Init(EnemyPool enemyPool, CharacterController characterController, BulletSystem bulletSystem, LevelBounds levelBounds)
        {
            _enemyPool = enemyPool;
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
            _enemyPool.UnspawnEnemy(this);
            
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
            
            var direction = (transform.position - _characterController.transform.position).normalized;
            Fire(direction);
            yield return new WaitForSeconds(_countdownFire);
        }
    }
}