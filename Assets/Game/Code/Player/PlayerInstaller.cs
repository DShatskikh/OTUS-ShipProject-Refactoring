using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class PlayerInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private Transform _root;
        
        [SerializeField]
        private Transform _rootVisual;
        
        [SerializeField]
        private float _moveSpeed;
        
        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimatorDispatcher _animatorDispatcher;
        
        public override void Install(IEntity entity)
        {
            entity.AddRoot(_root);
            entity.AddRootVisual(_rootVisual);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddAnimator(_animator);
            entity.AddIsShot(false);
            entity.AddAnimatorDispatcher(_animatorDispatcher);
            entity.AddAmmo(4);
            entity.AddMaxAmmo(4);
            entity.AddHitPoints(4);
            entity.AddKills(0);
            entity.AddShotCooldown(0.5f);
            
            entity.AddBehaviour(new MoveBehaviour());
            entity.AddBehaviour(new RotateToMouseBehaviour());
            entity.AddBehaviour(new ShotBehaviour());
            entity.AddBehaviour(new AddAmmoToTimerBehaviour());
        }
    }
}