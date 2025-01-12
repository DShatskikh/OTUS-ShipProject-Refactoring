using System.Collections.Generic;
using System.Linq;
using GameCycle;
using UnityEngine;
using Zenject;

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
        private Pool _pool;

        public EntityType GetEntityType => _entityType;
        public int GetDamage => _damage;

        [Inject]
        private void Construct(Pool pool)
        {
            _pool = pool;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICrashBullet crashBullet))
            {
                crashBullet.Crash(this);
                _pool.TryDespawned(this);
            }
        }

        public void SetData(Data data)
        {
            _rigidbody2D.velocity = data.Velocity;
            gameObject.layer = (int)data.Config.PhysicsLayer;
            transform.position = data.Position;
            _spriteRenderer.color = data.Config.Color;
            _damage = data.Config.Damage;
            _entityType = data.EntityType;
        }

        public void Crash(Bullet bullet)
        {
            _pool.TryDespawned(bullet);
            _pool.TryDespawned(this);
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
        
        public struct Data
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public BulletConfig Config;
            public EntityType EntityType;
        }

        public sealed class Pool : MemoryPool<Bullet>
        {
            private readonly Transform _inactiveContainer;
            private readonly Transform _activateContainer;
            private readonly List<Bullet> _activateBullets = new();
            private readonly GameStateController _gameStateController;

            public IEnumerable<Bullet> ActivateBullets => _activateBullets;

            public Pool(GameStateController gameStateController, Transform inactiveContainer, Transform activateContainer)
            {
                _gameStateController = gameStateController;
                _inactiveContainer = inactiveContainer;
                _activateContainer = activateContainer;
            }

            protected override void OnCreated(Bullet item)
            {
                base.OnCreated(item);
                item.transform.SetParent(_inactiveContainer);
            }

            protected override void OnSpawned(Bullet item)
            {
                base.OnSpawned(item);
                item.transform.SetParent(_activateContainer);
                _activateBullets.Add(item);
                _gameStateController.AddListener(item);
            }

            protected override void OnDespawned(Bullet item)
            {
                _gameStateController.RemoveListener(item);
                item.transform.SetParent(_inactiveContainer);
                _activateBullets.Remove(item);
                base.OnDespawned(item);
            }

            public bool TryDespawned(Bullet bullet)
            {
                if (_activateBullets.Any(item => item == bullet))
                {
                    Despawn(bullet);
                    return true;
                }

                return false;
            }
        }
    }
}