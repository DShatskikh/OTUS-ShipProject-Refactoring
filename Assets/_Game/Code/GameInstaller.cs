using Game.Inventory;
using Game.Systems;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private InventoryView _inventoryView;
        
        [SerializeField]
        private AttackSystem _attackSystem;
        
        [SerializeField]
        private HealthSystem _healthSystem;
        
        [SerializeField]
        private SpeedSystem _speedSystem;

        [SerializeField]
        private MirrorView _mirrorView;
        
        public override void InstallBindings()
        {
            BindSystems();
            BindInventories();
            BindItemComponentObservers();
            BindUI();
        }

        private void BindSystems()
        {
            Container.Bind<ArmorSystem>().AsSingle().NonLazy();
            Container.Bind<AttackSystem>().FromInstance(_attackSystem).AsSingle().NonLazy();
            Container.Bind<HealthSystem>().FromInstance(_healthSystem).AsSingle().NonLazy();
            Container.Bind<SpeedSystem>().FromInstance(_speedSystem).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<DoubleClickDetector>().AsCached().NonLazy();
        }

        private void BindInventories()
        {
            Container.Bind<MainInventory>().AsSingle().WithArguments(new Vector2Int(9, 3)).NonLazy();
            Container.Bind<ArmorInventory>().AsSingle().NonLazy();
            Container.Bind<CraftInventory>().AsSingle().NonLazy();
        }

        private void BindItemComponentObservers()
        {
            Container.Bind<ItemArmorComponentObserver>().AsSingle().NonLazy();
            Container.Bind<ItemHealthComponentObserver>().AsSingle().NonLazy();
            Container.Bind<ItemSpeedComponentObserver>().AsSingle().NonLazy();
        }

        private void BindUI()
        {
            Container.Bind<MirrorPresenter>().AsSingle().WithArguments(_mirrorView).NonLazy();
            Container.BindInterfacesAndSelfTo<InventoryPresenter>().AsCached().WithArguments(_inventoryView).NonLazy();
        }
    }
}