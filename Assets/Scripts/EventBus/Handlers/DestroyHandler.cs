using UnityEngine;

namespace Game
{
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly UnitsManager _unitsManager;
        private readonly EventBus _eventBus;

        public DestroyHandler(EventBus eventBus, UnitsManager unitsManager) : base(eventBus)
        {
            _eventBus = eventBus;
            _unitsManager = unitsManager;
        }

        protected override void OnHandleEvent(DestroyEvent evt)
        {
            _unitsManager.RemoveUnit(evt.Unit);
            _eventBus.RaiseEvent(new SoundPlayEvent(evt.Unit.GetConfig.GetDeathSound));
            Object.Destroy(evt.Unit.gameObject);
        }
    }
}