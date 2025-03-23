using System;
using System.Linq;
using Game.Systems;
using UnityEngine;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class SpeedArmorComponent : IItemComponent
    {
        public int Speed;
        
        private ArmorInventory _inventory;
        private SpeedSystem _speedSystem;

        [Inject]
        public void Construct(ArmorInventory inventory, SpeedSystem speedSystem)
        {
            _inventory = inventory;
            _speedSystem = speedSystem;
            
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
            return new SpeedArmorComponent()
            {
                Speed = Speed
            };
        }

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _speedSystem.AddSpeed(Speed);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _speedSystem.RemoveSpeed(Speed);
        }
    }
}