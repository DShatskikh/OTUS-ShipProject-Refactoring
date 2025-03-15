

using System;
using Game.Gameplay.Conveyors;
using Object = UnityEngine.Object;

namespace Game.Meta
{
    public sealed class SizeLoadingAreaUpgrade : SawmillUpgrade
    {
        public override int NextImprovement => 4;
        public override event Action<int> OnLevelUp;
        public override string CurrentStats 
        {
            get
            {
                ConveyorModel conveyorModel = Object.FindAnyObjectByType<ConveyorModel>();
                return conveyorModel.core.loadStorage.MaxValue.ToString();
            }
        }
        
        public override void LevelUp()
        {
            _index++;
            ConveyorModel conveyorModel = Object.FindAnyObjectByType<ConveyorModel>();
            conveyorModel.core.loadStorage.MaxValue += 4;
            OnLevelUp?.Invoke(_index);
        }
    }
}