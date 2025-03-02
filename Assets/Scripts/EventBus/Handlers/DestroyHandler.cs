using UnityEngine;

namespace Game
{
    public class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly UnitsManager _unitsManager;

        public DestroyHandler(EventBus eventBus, UnitsManager unitsManager) : base(eventBus)
        {
            _unitsManager = unitsManager;
        }

        protected override void OnHandleEvent(DestroyEvent evt)
        {
            _unitsManager.RemoveUnit(evt.Unit);
            AudioPlayer.Instance.PlaySound(evt.Unit.GetConfig.GetDeathSound);
            Object.Destroy(evt.Unit.gameObject);
        }
    }
}