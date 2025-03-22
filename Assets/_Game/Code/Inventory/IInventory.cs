using System;
using UnityEngine;

namespace Game.Inventory
{
    public interface IInventory
    {
        event Action<InventoryItem, int, int> OnSlotChange;
        InventoryItem[,] Items { get; set; }
        void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, int x, int y);
        bool TrySwitchItem(IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition);
        bool CanSetItem(Vector3Int position, InventoryItem item);
    }
}