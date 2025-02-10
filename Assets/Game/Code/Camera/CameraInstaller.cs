using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CameraInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private Transform _target;

        public override void Install(IEntity entity)
        {
            entity.AddTarget(_target);
            entity.AddRoot(transform);

            entity.AddBehaviour(new CameraMoveToTargetBehaviour());
        }
    }
}