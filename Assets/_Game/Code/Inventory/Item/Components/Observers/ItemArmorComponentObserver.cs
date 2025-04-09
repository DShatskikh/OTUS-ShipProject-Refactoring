using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    public sealed class ItemArmorComponentObserver
    {
        private readonly ArmorInventory _armorInventory;
        private readonly ArmorSystem _armorSystem;

        [Inject]
        public ItemArmorComponentObserver(ArmorInventory armorInventory, ArmorSystem armorSystem)
        {
            _armorInventory = armorInventory;
            _armorSystem = armorSystem;

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

            _armorSystem.AddArmor(armorComponent.Armor);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out ArmorComponent armorComponent))
                return;

            _armorSystem.RemoveArmor(armorComponent.Armor);
        }
    }
}