namespace Game
{
    public sealed class PassiveAbilityHandler : BaseHandler<AttackEvent>
    {
        private readonly UnitsManager _unitsManager;

        public PassiveAbilityHandler(EventBus eventBus, UnitsManager unitsManager) : base(eventBus)
        {
            _unitsManager = unitsManager;
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {
            foreach (var unit in _unitsManager.GetTurnUnits) 
                unit.ActivatePassiveAbility();

            foreach (var enemy in _unitsManager.GetTurnEnemyUnits) 
                enemy.ActivatePassiveAbility();
        }
    }
}