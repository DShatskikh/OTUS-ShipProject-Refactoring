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
            this.Container.Bind<ApplicationExiter>().AsSingle().NonLazy();
            this.Container.Bind<GameLoader>().AsSingle().WithArguments(_loadingScreenPrefab).NonLazy();
            this.Container.Bind<MenuLoader>().AsSingle().WithArguments(_loadingScreenPrefab).NonLazy();
        }
    }
}