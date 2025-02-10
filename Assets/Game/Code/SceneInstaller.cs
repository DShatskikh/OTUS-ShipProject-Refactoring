using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class SceneInstaller : SceneContextInstallerBase
    {
        [SerializeField]
        private PlayerInput _playerInput;
        
        [SerializeField]
        private SceneEntity _player;
        
        public override void Install(IContext context)
        {
            context.AddPlayerInput(_playerInput);
            context.AddPlayer(_player);
        }
    }
}