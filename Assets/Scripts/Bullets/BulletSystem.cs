using System;
using System.Linq;

namespace ShootEmUp
{
    [Serializable]
    public sealed class BulletSystem : IGameFixedUpdateListener
    {
        private readonly LevelBounds _levelBounds;
        private readonly Bullet.Pool _pool;

        private BulletSystem(LevelBounds levelBounds, Bullet.Pool pool)
        {
            _levelBounds = levelBounds;
            _pool = pool;
        }

        public void OnFixedUpdate()
        {
            for (int i = 0; i < _pool.ActivateBullets.Count(); i++)
            {
                var bullet = _pool.ActivateBullets.ToArray()[i];

                if (_levelBounds.InBounds(bullet.transform.position))
                    continue;
                
                _pool.TryDespawned(bullet);
                return;
            }
        }

        public void FlyBulletByArgs(Bullet.Data data)
        {
            var bullet = _pool.Spawn();
            bullet.Init(data);
        }
    }
}