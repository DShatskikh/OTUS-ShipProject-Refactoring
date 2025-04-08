using System;
using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HealthComponent : IItemComponent
    {
        public int Health;
        
        private ArmorInventory _armorInventory;
        private HealthSystem _healthSystem;

        [Inject]
        public void Construct(ArmorInventory armorInventory, HealthSystem healthSystem)
        {
            _armorInventory = armorInventory;
            _healthSystem = healthSystem;
            
            armorInventory.OnItemAdded += OnItemAdded;
            armorInventory.OnItemRemoved += OnItemRemoved;
        }

        public void OnDispose()
        {
            _armorInventory.OnItemAdded -= OnItemAdded;
            _armorInventory.OnItemRemoved -= OnItemRemoved;
        }

        public IItemComponent Clone()
        {
            return new HealthComponent()
            {
                Health = Health
            };
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _healthSystem.AddHealth(Health);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _healthSystem.RemoveHealth(Health);
        }
    }
}