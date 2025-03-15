using Entities;

namespace Lessons.Lesson19_EventBus
{
    public sealed class AttackHandler : BaseEventHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void OnEventInvoked(AttackEvent evt)
        {
            var source = evt.Source;
            
            if (source.TryGet(out StatsComponent stats))
            {
                EventBus.RaiseEvent(new DealDamageEvent(evt.Target, stats.Strength));
            }
            
            if(source.TryGet(out WeaponComponent weaponComponent))
            {
                var effects = weaponComponent.WeaponConfig.Effects;
                
                foreach (IWeaponEffect effect in effects)
                {
                    effect.Source = evt.Source;
                    effect.Target = evt.Target;
                    EventBus.RaiseEvent(effect);
                }
            }
        }
    }
    
    public class AttackEvent
    {
        public readonly IEntity Source;
        public readonly IEntity Target;

        public AttackEvent(IEntity source, IEntity target)
        {
            Source = source;
            Target = target;
        }
    }
}