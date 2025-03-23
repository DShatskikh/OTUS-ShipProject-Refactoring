using System;
using UnityEngine;

namespace Game.Inventory
{
    public sealed class QuickAccessInventory : IInventory
    {
        public InventoryItem[,] Items { get; set; } = new InventoryItem[9, 1];
        public event Action<InventoryItem, int, int> OnSlotChange;
        
        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, int x, int y)
        {
            OnSlotChange?.Invoke(item, x, y);
        }

        public bool TrySwitchItem(IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition) => 
            InventoryUseCases.TrySwitchItem(this, selectedInventory, position, selectSlotPosition);

        public bool CanSetItem(Vector3Int position, InventoryItem item)
        {
            return true;
        }
    }
}