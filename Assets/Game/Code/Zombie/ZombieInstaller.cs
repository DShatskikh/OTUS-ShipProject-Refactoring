using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ZombieInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimatorDispatcher _animatorDispatcher;
        
        public override void Install(IEntity entity)
        {
            entity.AddHitPoints(1);
            entity.AddRoot(transform);
            entity.AddMoveSpeed(_speed);
            entity.AddTarget(SceneContext.Instance.GetPlayer().GetRoot());
            entity.AddAnimator(_animator);
            entity.AddAnimatorDispatcher(_animatorDispatcher);

            entity.AddBehaviour(new DestroyToZeroHitPointsBehaviour());
            entity.AddBehaviour(new MoveToTargetBehaviour());
            entity.AddBehaviour(new AttackTargetBehaviour());
        }
    }
}