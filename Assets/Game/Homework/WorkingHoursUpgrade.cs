using System;
using Game.Gameplay.Conveyors;
using Object = UnityEngine.Object;

namespace Game.Meta
{
    [Serializable]
    public sealed class WorkingHoursUpgrade : SawmillUpgrade
    {
        public override int NextImprovement => -1;
        public override event Action<int> OnLevelUp;

        public override string CurrentStats
        {
            get
            {
                ConveyorModel conveyorModel = Object.FindAnyObjectByType<ConveyorModel>();
                return conveyorModel.core.workTimer.Duration.ToString();
            }
        }

        public override void LevelUp()
        {
            _index++;
            ConveyorModel conveyorModel = Object.FindAnyObjectByType<ConveyorModel>();
            conveyorModel.core.workTimer.Duration -= 1;
            OnLevelUp?.Invoke(_index);
        }
    }
}