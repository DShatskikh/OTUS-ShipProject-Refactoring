using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private EntityType _entityType;
        private int _damage;
        private BulletSystem _bulletSystem;

        public struct Data
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public BulletConfig Config;
            public EntityType EntityType;
        }

        private void Awake()
        {
            _bulletSystem = DIContainer.Get<BulletSystem>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                _bulletSystem.RemoveBullet(this);
                _bulletSystem.RemoveBullet(bullet);
            }
            else if (other.TryGetComponent(out Unit unit))
            {
                if (_entityType != unit.GetEntityType)
                {
                    unit.TakeDamage(_damage);   
                    _bulletSystem.RemoveBullet(this);
                }
            }
        }

        public void Init(Data data)
        {
            _rigidbody2D.velocity = data.Velocity;
            gameObject.layer = (int)data.Config.PhysicsLayer;
            transform.position = data.Position;
            _spriteRenderer.color = data.Config.Color;
            _damage = data.Config.Damage;
            _entityType = data.EntityType;
        }
    }
}