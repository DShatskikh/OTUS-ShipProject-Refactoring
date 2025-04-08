using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HealthConsumedComponent : IItemComponent
    {
        private MainInventory _inventory;

        public int Health;

        public void Construct(MainInventory inventory)
        {
            _inventory = inventory;
            inventory.OnItemConsumed += OnItemConsumed;
        }

        public void OnDispose()
        {
            _inventory.OnItemConsumed -= OnItemConsumed;
        }

        public IItemComponent Clone()
        {
            return new HealthConsumedComponent()
            {
                Health = Health
            };
        }

        private void OnItemConsumed(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            Debug.Log("Add Health");
        }
    }
}