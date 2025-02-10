using Atomic.Entities;
using UnityEngine;

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
            entity.AddPrefab(_prefab);
            entity.AddPoints(_points);

            entity.AddBehaviour(new SpawnerBehaviour());
        }
    }
}