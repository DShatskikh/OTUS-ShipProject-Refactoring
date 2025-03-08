using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Game
{
    public sealed class UnitsManager
    {
        private readonly List<Unit> _redUnits;
        private readonly List<Unit> _blueUnits;
        private readonly EventBus _eventBus;

        private CommandEnum _turnCommand;
        private Unit _selectUnit;
        private Unit _selectEnemyUnit;

        public List<Unit> GetTurnUnits => _turnCommand == CommandEnum.Red ? _blueUnits : _redUnits;
        public List<Unit> GetTurnEnemyUnits => _turnCommand == CommandEnum.Red ? _redUnits : _blueUnits;
        public CommandEnum GetTurnCommand => _turnCommand;
        public Unit GetSelectUnit => _selectUnit;
        public Unit GetSelectEnemyUnit => _selectEnemyUnit;
        public List<Unit> GetRedUnits => _redUnits;
        public List<Unit> GetBlueUnits => _blueUnits;

        public UnitsManager(Unit[] redUnits, List<Unit> blueUnits, EventBus eventBus)
        {
            _redUnits = redUnits.ToList();
            _blueUnits = blueUnits;
            _eventBus = eventBus;
        }

        public void Select(Unit unit)
        {
            _selectUnit = unit;
            unit.ToggleSelect(true);
        }

        public void SelectEnemy(Unit unit)
        {
            _selectEnemyUnit = unit;
            unit.ToggleSelect(true);
        }

        public void Next()
        {
            _selectUnit.ToggleSelect(false);
            _selectEnemyUnit.ToggleSelect(false);

            _turnCommand = _turnCommand == CommandEnum.Red ? CommandEnum.Blue : CommandEnum.Red;
        }

        public void Turn()
        {
            _eventBus.RaiseEvent(new DamageEvent(_selectEnemyUnit, _selectUnit.GetAttack));
            _eventBus.RaiseEvent(new DamageEvent(_selectUnit, _selectEnemyUnit.GetAttack));
        }

        public void Turn(Unit enemy)
        {
            _eventBus.RaiseEvent(new DamageEvent(enemy, _selectUnit.GetAttack));
            _eventBus.RaiseEvent(new DamageEvent(_selectUnit, enemy.GetAttack));
        }
        
        public UniTask UpgradeVisualAllUnits()
        {
            foreach (var blue in _blueUnits) 
                blue.AnimationUpgradeStats();
            
            foreach (var red in _redUnits) 
                red.AnimationUpgradeStats();
            
            return UniTask.Delay(2000);
        }

        public void RemoveUnit(Unit unit)
        {
            _blueUnits.Remove(unit);
            _redUnits.Remove(unit);
        }
    }

    public enum CommandEnum
    {
        Red,
        Blue
    }
}