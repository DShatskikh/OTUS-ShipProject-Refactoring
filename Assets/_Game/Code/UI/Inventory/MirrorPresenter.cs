using Game.Inventory;

namespace Game.UI
{
    public sealed class MirrorPresenter
    {
        private readonly MirrorView _view;
        private readonly ArmorInventory _armorInventory;

        public MirrorPresenter(MirrorView view, ArmorInventory armorInventory)
        {
            _view = view;
            _armorInventory = armorInventory;
            
            _armorInventory.OnItemAdded += OnItemAdded;
            _armorInventory.OnItemRemoved += OnItemRemoved;
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (ItemUseCases.TryGetComponent(item, out HelmetComponent helmetComponent))
            {
                _view.SetHelmet(helmetComponent.PlayerSprite);   
                _view.ToggleHelmet(true);   
            }
            
            if (ItemUseCases.TryGetComponent(item, out ChestplateComponent chestplateComponent))
            {
                _view.SetChestplate(chestplateComponent.PlayerSprite);   
                _view.ToggleChestplate(true);   
            }
            
            if (ItemUseCases.TryGetComponent(item, out LeggingsComponent leggingsComponent))
            {
                _view.SetLeggings(leggingsComponent.PlayerSprite);   
                _view.ToggleLeggings(true);   
            }
            
            if (ItemUseCases.TryGetComponent(item, out BootsComponent bootsComponent))
            {
                _view.SetBoots(bootsComponent.PlayerSprite);   
                _view.ToggleBoots(true);   
            }
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (ItemUseCases.TryGetComponent(item, out HelmetComponent helmetComponent)) 
                _view.ToggleHelmet(false);
            
            if (ItemUseCases.TryGetComponent(item, out ChestplateComponent chestplateComponent)) 
                _view.ToggleChestplate(false);
            
            if (ItemUseCases.TryGetComponent(item, out LeggingsComponent leggingsComponent)) 
                _view.ToggleLeggings(false);
            
            if (ItemUseCases.TryGetComponent(item, out BootsComponent bootsComponent)) 
                _view.ToggleBoots(false);
        }
    }
}