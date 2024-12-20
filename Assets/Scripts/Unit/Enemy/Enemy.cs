using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Unit
    {
        private const float StopDistance = 0.25f;
        
        [SerializeField]
        private float _countdownFire = 1f;
        
        private EnemyPool _enemyPool;
        private CharacterController _characterController;

        protected override EntityType GetEntityType =>
            EntityType.Enemy;

        public void Init(EnemyPool enemyPool, CharacterController characterController, BulletSystem bulletSystem, LevelBounds levelBounds)
        {
            _enemyPool = enemyPool;
            _characterController = characterController;
            
            Init(bulletSystem, levelBounds);
        }

        public void StartWork(Vector2 destination)
        {
            StartCoroutine(AwaitWork(destination));
        }

        protected override void Die()
        {
            _enemyPool.UnspawnEnemy(this);
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
                yield return null;
                var vector = destination - (Vector2)transform.position;
                var direction = vector.normalized * Time.fixedDeltaTime;
                Move(direction);
            }
        }

        private IEnumerator AwaitAttack()
        {
            var direction = (transform.position - _characterController.transform.position).normalized;
            Fire(direction);
            yield return new WaitForSeconds(_countdownFire);
        }
    }
}