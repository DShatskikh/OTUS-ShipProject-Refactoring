using System;
using Game.Gameplay.Conveyors;
using Object = UnityEngine.Object;

namespace Game.Meta
{
    public sealed class VolumeUnloadingAreaUpgrade : SawmillUpgrade
    {
        public override int NextImprovement => 4;
        public override event Action<int> OnLevelUp;
        public override string CurrentStats 
        {
            get
            {
                ConveyorModel conveyorModel = UnityEngine.Object.FindAnyObjectByType<ConveyorModel>();
                return conveyorModel.core.unloadStorage.MaxValue.ToString();
            }
        }
        
        public override void LevelUp()
        {
            _index++;
            ConveyorModel conveyorModel = Object.FindAnyObjectByType<ConveyorModel>();
            conveyorModel.core.unloadStorage.MaxValue += 4;
            OnLevelUp?.Invoke(_index);
        }
    }
}