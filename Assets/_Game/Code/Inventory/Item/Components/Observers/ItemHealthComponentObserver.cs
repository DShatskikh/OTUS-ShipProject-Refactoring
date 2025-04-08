using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    public sealed class ItemHealthComponentObserver
    {
        private readonly ArmorInventory _armorInventory;
        private readonly HealthSystem _healthSystem;

        [Inject]
        private ItemHealthComponentObserver(ArmorInventory armorInventory, HealthSystem healthSystem)
        {
            _armorInventory = armorInventory;
            _healthSystem = healthSystem;
            
            _armorInventory.OnItemAdded += OnItemAdded;
            _armorInventory.OnItemRemoved += OnItemRemoved;
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out HealthComponent healthComponent))
                return;

            _healthSystem.AddHealth(healthComponent.Health);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.TryGetComponent(item, out HealthComponent healthComponent))
                return;

            _healthSystem.RemoveHealth(healthComponent.Health);
        }
    }
}