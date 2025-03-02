namespace Game
{
    public sealed class DamageHandler : BaseHandler<DamageEvent>
    {
        private readonly UnitsManager _unitsManager;
        private readonly EventBus _eventBus;

        public DamageHandler(EventBus eventBus, UnitsManager unitsManager) : base(eventBus)
        {
            _eventBus = eventBus;
            _unitsManager = unitsManager;
        }

        protected override void OnHandleEvent(DamageEvent evt)
        {
            var unit = evt.Unit;
            var damage = unit.GetAttack;
            
            unit.HealthSubtract(damage);
            
            if (unit.GetHealth < unit.GetConfig.GetHealth * 0.2f)
                AudioPlayer.Instance.PlaySound(evt.Unit.GetConfig.GetLowHealthSound);

            if (unit.GetConfig.GetHealthSubtractAbilities != null)
            {
                foreach (var ability in unit.GetConfig.GetHealthSubtractAbilities) 
                    ability.Activate(_unitsManager, _eventBus);
            }
            
            if (unit.GetHealth <= 0)
                _eventBus.RaiseEvent(new DestroyEvent(unit));
        }
    }
}