using System;
using UnityEngine;

namespace Game.Inventory
{
    public sealed class HandInventory : IInventory
    {
        public InventoryItem[,] Items { get; set; } = new InventoryItem[1, 1];
        
        public event Action<InventoryItem, int, int> OnSlotChange;
        public event Action<InventoryItem> OnItemAdded; 
        public event Action<InventoryItem> OnItemRemoved; 

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

        public bool CanSetItem(Vector3Int position, InventoryItem item) => 
            true;
    }
}