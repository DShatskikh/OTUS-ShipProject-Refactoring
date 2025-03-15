using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class DeathAnimationBehaviour : IEntityInit
    {
        private Animator _animator;
        private static readonly int s_isDead = Animator.StringToHash("IsDead");

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetIsDead().Subscribe(OnIsDeadChanged);
        }

        private void OnIsDeadChanged(bool isDead)
        {
            _animator.SetBool(s_isDead, isDead);
        }
    }
}