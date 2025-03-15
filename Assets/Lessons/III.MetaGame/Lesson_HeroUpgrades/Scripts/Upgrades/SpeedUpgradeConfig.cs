using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_HeroUpgrades
{
    [CreateAssetMenu(
        fileName = "SpeedUpgradeConfig",
        menuName = "Configs/Upgrade/New SpeedUpgradeConfig"
    )]
    public class SpeedUpgradeConfig : UpgradeConfig
    {
        public MoveSpeedTable MoveSpeedTable;
        
        public override Upgrade Create()
        {
            return new SpeedUpgrade(this);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            MoveSpeedTable.OnValidate(MaxLevel);
        }
    }
}