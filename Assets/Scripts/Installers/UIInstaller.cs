using Zenject;

namespace ShootEmUp
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<StartGameScreen>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<PauseGameScreen>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<EndGameScreen>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<MainGameScreen>().FromComponentInHierarchy().AsSingle();
        }
    }
}