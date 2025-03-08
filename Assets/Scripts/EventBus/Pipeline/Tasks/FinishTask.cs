using UI;
using UnityEngine;

namespace Game
{
    public sealed class FinishTask : EventTask
    {
        private readonly EndGameScreen _endGameScreen;
        private readonly UnitsManager _manager;

        public FinishTask(EndGameScreen endGameScreen, UnitsManager manager)
        {
            _endGameScreen = endGameScreen;
            _manager = manager;
        }
        
        protected override void OnRun()
        {
            if (_manager.GetRedUnits.Count == 0 || _manager.GetBlueUnits.Count == 0)
            {
                _endGameScreen.ToggleShow(true);
                _endGameScreen.SetLabelText(_manager.GetRedUnits.Count != 0 ? "Красные победили" : "Синие победили");
                Debug.Log("Игра завершилась");
                return;
            }
            
            Finish();
        }
    }
}