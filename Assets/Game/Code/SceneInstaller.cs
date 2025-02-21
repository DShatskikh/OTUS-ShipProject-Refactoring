using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class SceneInstaller : SceneContextInstallerBase
    {
        [SerializeField]
        private SceneEntity _player;
        
        public override void Install(IContext context)
        {
            context.AddPlayer(_player);
            context.AddIsPlaying(new BoolSerialize(true));
        }
    }
}