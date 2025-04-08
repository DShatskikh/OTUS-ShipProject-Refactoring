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

            foreach (var slot in _armorInventory.GetArmorSlots)
            {
                slot.OnItemAdded += OnItemAdded;
                slot.OnItemRemoved += OnItemRemoved;
            }
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out ArmorComponent armorComponent))
                return;

            var armorType = armorComponent.ArmorType;
            
            if (armorType == ArmorType.Helmet)
            {
                _view.SetHelmet(armorComponent.PlayerSprite);   
                _view.ToggleHelmet(true);   
            }
            
            if (armorType == ArmorType.Chestplate)
            {
                _view.SetChestplate(armorComponent.PlayerSprite);   
                _view.ToggleChestplate(true);   
            }
            
            if (armorType == ArmorType.Leggings)
            {
                _view.SetLeggings(armorComponent.PlayerSprite);   
                _view.ToggleLeggings(true);   
            }
            
            if (armorType == ArmorType.Boots)
            {
                _view.SetBoots(armorComponent.PlayerSprite);   
                _view.ToggleBoots(true);   
            }
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out ArmorComponent armorComponent))
                return;

            var armorType = armorComponent.ArmorType;
            
            if (armorType == ArmorType.Helmet) 
                _view.ToggleHelmet(false);
            
            if (armorType == ArmorType.Chestplate) 
                _view.ToggleChestplate(false);
            
            if (armorType == ArmorType.Leggings) 
                _view.ToggleLeggings(false);
            
            if (armorType == ArmorType.Boots) 
                _view.ToggleBoots(false);
        }
    }
}