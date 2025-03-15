namespace Lessons.Lesson19_EventBus
{
    public class ForceWeaponHandler : BaseEventHandler<ForceWeaponEffect>
    {
        public ForceWeaponHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void OnEventInvoked(ForceWeaponEffect evt)
        {
            EventBus.RaiseEvent(new ForceDirectionEvent(evt.Source, evt.Target, 1));
        }
    }
}