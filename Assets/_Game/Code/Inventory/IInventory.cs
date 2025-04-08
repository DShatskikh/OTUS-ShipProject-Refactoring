using System;

namespace Game.Inventory
{
    public interface IInventory
    {
        event Action<InventoryItem, Slot> OnSlotChange;
        void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, Slot slot);
    }
}