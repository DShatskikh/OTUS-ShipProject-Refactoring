using System;
using System.Linq;
using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HealthArmorComponent : IItemComponent
    {
        public int Health;
        
        private ArmorInventory _inventory;
        private HealthSystem _healthSystem;

        [Inject]
        public void Construct(ArmorInventory inventory, HealthSystem healthSystem)
        {
            _inventory = inventory;
            _healthSystem = healthSystem;
            
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemRemoved += OnItemRemoved;
        }

        public void OnDispose()
        {
            _inventory.OnItemAdded -= OnItemAdded;
            _inventory.OnItemRemoved -= OnItemRemoved;
        }

        public IItemComponent Clone()
        {
            return new HealthArmorComponent()
            {
                Health = Health
            };
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (item == null)
                return;
            
            var component = item.Components.FirstOrDefault(x => x == this);
            
            if (component != this)
                return;
            
            _healthSystem.AddHealth(Health);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (item == null)
                return;
            
            var component = item.Components.FirstOrDefault(x => x == this);
            
            if (component != this)
                return;
            
            _healthSystem.RemoveHealth(Health);
        }
    }
}