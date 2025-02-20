using SaveSystem;
using Zenject;

namespace GameEngine
{
    public sealed class GameCoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SettingService>().AsSingle();
            Container.Bind<SettingsRepository>().AsSingle();
        }
    }
}