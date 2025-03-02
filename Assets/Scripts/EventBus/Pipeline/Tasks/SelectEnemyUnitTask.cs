using UnityEngine;

namespace Game
{
    public sealed class SelectEnemyUnitTask : EventTask
    {
        private readonly UnitsManager _unitsManager;
        private readonly EventBus _eventBus;

        public SelectEnemyUnitTask(UnitsManager unitsManager, EventBus eventBus)
        {
            _unitsManager = unitsManager;
            _eventBus = eventBus;
        }
        
        protected override void OnRun()
        {
            Debug.Log("выбор противника");

            foreach (var unit in _unitsManager.GetTurnEnemyUnits)
            {
                unit.ToggleInteractable(true);
                unit.Select += OnSelect;
            }
        }

        protected override void OnFinish()
        {
            Debug.Log("OnFinish");
        }

        private void OnSelect(Unit unit)
        {
            Debug.Log("конец выбора противника");
            _unitsManager.SelectEnemy(unit);
            
            foreach (var unitEnemy in _unitsManager.GetTurnEnemyUnits)
            {
                unitEnemy.ToggleInteractable(false);
                unitEnemy.Select -= OnSelect;
            }

            _eventBus.RaiseEvent(new AttackEvent());
            _eventBus.RaiseEvent(new PassiveAbilityEvent());
            _unitsManager.Next();
            Finish();
        }
    }
}