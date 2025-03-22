using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ArmorInventory : IInventory
    {
        public InventoryItem[,] Items { get; set; } = new InventoryItem[1, 4];

        public event Action<InventoryItem> OnItemAdded;
        public event Action<InventoryItem> OnItemRemoved;
        public event Action<InventoryItem, int, int> OnSlotChange;
        
        public void NotifyAddItem(InventoryItem item) => 
            OnItemAdded?.Invoke(item);

        public void NotifyRemoveItem(InventoryItem item) => 
            OnItemRemoved?.Invoke(item);

        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, int x, int y)
        {
            if (previousItem != null)
                OnItemRemoved?.Invoke(previousItem);
            
            if (item != null)
                OnItemAdded?.Invoke(item);
            
            OnSlotChange?.Invoke(item, x, y);
        }
        
        public bool TrySwitchItem(IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition) => 
            InventoryUseCases.TrySwitchItem(this, selectedInventory, position, selectSlotPosition);

        public bool CanSetItem(Vector3Int position, InventoryItem item)
        {
            switch (position.y)
            {
                case 0:
                    return ArmorInventoryUseCases.IsCanSetHelmetItem(this, item);

                case 1:
                    return ArmorInventoryUseCases.IsCanSetChestplateItem(this, item);
                
                case 2:
                    return ArmorInventoryUseCases.IsCanSetLeggingsItem(this, item);
                
                case 3:
                    return ArmorInventoryUseCases.IsCanSetBootsItem(this, item);
                
                default:
                    return false;
            }
        }
    }
}