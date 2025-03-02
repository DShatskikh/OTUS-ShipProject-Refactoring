using UnityEngine;

namespace Game
{
    public class DamageVisualTask : EventTask
    {
        private readonly Unit _unit;
        private readonly Unit _enemyUnit;
        private readonly UnitsManager _unitsManager;

        public DamageVisualTask(Unit unit, Unit enemyUnit, UnitsManager unitsManager)
        {
            _unit = unit;
            _enemyUnit = enemyUnit;
            _unitsManager = unitsManager;
        }

        protected override async void OnRun()
        {
            if (_unit == null)
                return;
            
            Debug.Log("Анимация дамага");
            await _unit.GetView.AnimateAttack(_enemyUnit.GetView);
            _enemyUnit.PlayDamageEffect();
            await _unitsManager.UpgradeVisualAllUnits();
            Finish();
        }
    }
}