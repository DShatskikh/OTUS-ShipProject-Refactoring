using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Lessons.III.MetaGame.Lesson_HeroUpgrades
{
    public class SpeedUpgrade : Upgrade, IGameInitElement
    {
        private IHeroService _heroService;
        private SpeedUpgradeConfig _speedUpgradeConfig;

        public SpeedUpgrade(SpeedUpgradeConfig config) : base(config)
        {
            _speedUpgradeConfig = config;
        }

        void IGameInitElement.InitGame()
        {
            
        }

        [GameInject]
        public void Construct(IHeroService heroService)
        {
            _heroService = heroService;
        }

        protected override void OnUpgrade()
        {
            var hero = _heroService.GetHero();
            var moveSpeedComponent = hero.Get<IComponent_SetMoveSpeed>();
            var speed = _speedUpgradeConfig.MoveSpeedTable.GetSpeed(Level);
            moveSpeedComponent.SetSpeed(speed);
        }
    }
}