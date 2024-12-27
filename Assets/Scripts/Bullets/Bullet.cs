using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, ICrashBullet, IGameResumeListener, IGamePauseListener, IGameFinishListener
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        private BulletSystem _bulletSystem;
        
        private EntityType _entityType;
        private int _damage;
        private Vector2 _beforePauseVelocity;

        public EntityType GetEntityType => _entityType;
        public int GetDamage => _damage;

        public struct Data
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public BulletConfig Config;
            public EntityType EntityType;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICrashBullet crashBullet))
            {
                crashBullet.Crash(this);
                _bulletSystem.RemoveBullet(this);
            }
        }

        public void Init(Data data, BulletSystem bulletSystem)
        {
            _rigidbody2D.velocity = data.Velocity;
            gameObject.layer = (int)data.Config.PhysicsLayer;
            transform.position = data.Position;
            _spriteRenderer.color = data.Config.Color;
            _damage = data.Config.Damage;
            _entityType = data.EntityType;
            _bulletSystem = bulletSystem;
        }

        public void Crash(Bullet bullet)
        {
            _bulletSystem.RemoveBullet(bullet);
        }

        public void OnResumeGame()
        {
            _rigidbody2D.velocity = _beforePauseVelocity;
        }

        public void OnPauseGame()
        {
            _beforePauseVelocity = _rigidbody2D.velocity;
            _rigidbody2D.velocity = Vector2.zero;
        }

        public void OnFinishGame()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}