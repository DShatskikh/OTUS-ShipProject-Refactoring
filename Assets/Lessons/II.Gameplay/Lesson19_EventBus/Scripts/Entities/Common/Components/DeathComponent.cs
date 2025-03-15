using System;
using Atomic.Elements;

namespace Lessons.Lesson19_EventBus
{
    public sealed class DeathComponent
    {
        public event Action<bool> OnIsDeadChanged
        {
            add => _isDead.Subscribe(value);
            remove => _isDead.Unsubscribe(value);
        }
        
        public bool IsDead => _isDead.Value;

        private readonly AtomicVariable<bool> _isDead;

        public DeathComponent(AtomicVariable<bool> isDead)
        {
            _isDead = isDead;
        }

        public void Die()
        {
            _isDead.Value = true;
        }
    }
}