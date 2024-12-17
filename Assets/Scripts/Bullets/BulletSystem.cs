using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int _initialCount = 50;
        
        [SerializeField]
        private Transform _container;
        
        [SerializeField]
        private Bullet _prefab;
        
        [SerializeField]
        private Transform _worldTransform;
        
        private readonly Queue<Bullet> _bulletPool = new();
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        
        private LevelBounds _levelBounds;
        
        private void Awake()
        {
            _levelBounds = ServiceLocator.Get<LevelBounds>();
            
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Instantiate(_prefab, _container);
                _bulletPool.Enqueue(bullet);
            }
        }
        
        private void FixedUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                
                if (!_levelBounds.InBounds(bullet.transform.position)) 
                    RemoveBullet(bullet);
            }
        }

        public void FlyBulletByArgs(Bullet.Data data)
        {
            if (_bulletPool.TryDequeue(out var bullet))
                bullet.transform.SetParent(_worldTransform);
            else
                bullet = Instantiate(_prefab, _worldTransform);

            bullet.Init(data);
            _activeBullets.Add(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(_container);
                _bulletPool.Enqueue(bullet);
            }
        }
    }
}