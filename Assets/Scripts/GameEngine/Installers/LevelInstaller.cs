using SaveSystem;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitManager _unitManager;

        [SerializeField]
        private ResourceService _resourceService;
        
        public override void InstallBindings()
        {
            Container.Bind<UnitManager>().FromInstance(_unitManager).AsSingle();
            Container.Bind<ResourceService>().FromInstance(_resourceService).AsSingle();
            Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().AsSingle();
            Container.Bind<ISaveLoader>().To<ResourceLoader>().AsCached();
            Container.Bind<ISaveLoader>().To<UnitManagerLoader>().AsCached();
        }
    }
}