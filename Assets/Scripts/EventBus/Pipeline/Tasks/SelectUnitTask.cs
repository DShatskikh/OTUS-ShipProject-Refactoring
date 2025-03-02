using System.Linq;
using UnityEngine;

namespace Game
{
    public class SelectUnitTask : EventTask
    {
        private readonly UnitsManager _unitsManager;

        public SelectUnitTask(UnitsManager unitsManager)
        {
            _unitsManager = unitsManager;
        }

        protected override void OnRun()
        {
            Debug.Log("выбор юнита");

            if (_unitsManager.GetTurnUnits.All(x => x.GetFreeze))
            {
                Finish();
                return;
            }
            
            foreach (var unit in _unitsManager.GetTurnUnits)
            {
                if (unit.GetFreeze)
                {
                    unit.SetFreeze(false);
                    Debug.Log("Freeze " + unit.name);
                    continue;
                }

                unit.ToggleInteractable(true);
                unit.Select += OnSelect;
            }
        }

        protected override void OnFinish()
        {
            
        }

        private void OnSelect(Unit unit)
        {
            Debug.Log("конец выбора юнита");
            _unitsManager.Select(unit);

            foreach (var turnUnit in _unitsManager.GetTurnUnits)
            {
                turnUnit.ToggleInteractable(false);
                turnUnit.Select -= OnSelect;
            }
            
            Finish();
        }
    }
}