using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Unit
    {
        [SerializeField]
        private float _countdownFire = 1f;
        
        private EnemyPool _enemyPool;
        private CharacterController _characterController;

        public override EntityType GetEntityType =>
            EntityType.Enemy;

        protected override void Init()
        {
            base.Init();
            _enemyPool = ServiceLocator.Get<EnemyPool>();
            _characterController = ServiceLocator.Get<CharacterController>();
        }

        public void StartAttack(Vector2 destination) => 
            StartCoroutine(AwaitAttack(destination));

        protected override void Die() => 
            _enemyPool.UnspawnEnemy(this);

        private IEnumerator AwaitAttack(Vector2 destination)
        {
            while (Vector2.Distance(destination, transform.position) > 0.25f)
            {
                yield return null;
                var vector = destination - (Vector2)transform.position;
                var direction = vector.normalized * Time.fixedDeltaTime;
                Move(direction);
            }

            while (true)
            {
                yield return new WaitForSeconds(_countdownFire);
                var direction = (transform.position - _characterController.transform.position).normalized;
                Fire(direction);
            }
        }
    }
}