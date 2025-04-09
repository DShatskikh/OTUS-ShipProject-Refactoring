using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    public sealed class ItemSpeedComponentObserver
    {
        private readonly ArmorInventory _armorInventory;
        private readonly SpeedSystem _speedSystem;

        [Inject]
        public ItemSpeedComponentObserver(ArmorInventory armorInventory, SpeedSystem speedSystem)
        {
            _armorInventory = armorInventory;
            _speedSystem = speedSystem;
            
            foreach (var slot in _armorInventory.GetArmorSlots)
            {
                slot.OnItemAdded += OnItemAdded;
                slot.OnItemRemoved += OnItemRemoved;
            }
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out SpeedComponent speedComponent))
                return;

            _speedSystem.AddSpeed(speedComponent.Speed);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out SpeedComponent speedComponent))
                return;

            _speedSystem.RemoveSpeed(speedComponent.Speed);
        }
    }
}