using UnityEngine;
using Zenject;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "ProjectInstaller",
        menuName = "Installers/New ProjectInstaller"
    )]
    public sealed class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LoadingScreen _loadingScreenPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<ApplicationExiter>().AsSingle().NonLazy();
            Container.Bind<GameLoader>().AsSingle().WithArguments(_loadingScreenPrefab).NonLazy();
            Container.Bind<MenuLoader>().AsSingle().WithArguments(_loadingScreenPrefab).NonLazy();
            Container.Bind<IAssetLoader>().To<AddressablesManager>().AsSingle().NonLazy();
        }
    }
}