using SaveSystem;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _unitContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<UnitManager>().AsSingle().WithArguments(_unitContainer);
            Container.Bind<ResourceService>().AsSingle();
            Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
            Container.Bind<SaveLoadManager>().AsSingle();
            Container.Bind<ISaveLoader>().To<ResourceLoader>().AsCached();
            Container.Bind<ISaveLoader>().To<UnitManagerLoader>().AsCached();
        }
    }
}