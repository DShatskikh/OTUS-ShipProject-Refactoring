using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class SpawnerZombieInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private SceneEntity _prefab;

        [SerializeField]
        private Transform[] _points;

        public override void Install(IEntity entity)
        {
            var spawnTimer = new Timer(2f, true);
            spawnTimer.OnEnded += () =>
            {
                var point = _points[Random.Range(0, _points.Length)];
                var zombie = Instantiate(_prefab, point.position, quaternion.identity, point);
                zombie.AddTarget(SceneContext.Instance.GetPlayer().GetRoot());
            };
            entity.WhenUpdate(spawnTimer.Tick);
            spawnTimer.Play();
        }
    }
}