using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class CharacterVisualInstaller : SceneEntityInstallerBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationDispatcher _animationDispatcher;

        [SerializeField] private ShootVfxBehaviour _shootVfxBehaviour;
        
        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddAnimationDispatcher(_animationDispatcher);
            entity.AddBehaviour(new MovementAnimationBehaviour());
            entity.AddBehaviour(new DeathAnimationBehaviour());
            entity.AddBehaviour(new ShootAnimationBehaviour());

            entity.AddBehaviour(_shootVfxBehaviour);
        }
    }
}