using UnityEngine;

namespace Game.Inventory
{
    public static class InventoryUseCases
    {
        public static void AddItem(MainInventory inventory, InventoryItem item)
        {
            foreach (var slot in inventory.QuickAccessSlots)
            {
                if (SlotUseCases.TryAdd(slot, item, out int remains))
                {
                    if (remains == 0)
                        return;
                }
            }

            var mainSlots = inventory.MainSlots;
            
            for (int y = 0; y < mainSlots.GetLength(1); y++)
            {
                for (int x = 0; x < mainSlots.GetLength(0); x++)
                {
                    var slot = mainSlots[x, y];
                    
                    if (SlotUseCases.TryAdd(slot, item, out int remains))
                    {
                        if (remains == 0)
                            return;
                    }
                } 
            }
            
            Debug.Log("Предмет не поместился");
        }
        
        public static bool TryRemoveItem(IInventory inventory, InventoryItem item, int removeCount = 1)
        {
            throw new System.NotImplementedException();
        }

        public static void ConsumeItem(MainInventory inventory, InventoryItem item)
        {
            //RemoveItem(inventory, item);
            inventory.NotifyConsumeItem(item);
        }

        public static void SwitchItem(Slot currentSlot, Slot selectSlot)
        {
            throw new System.NotImplementedException();
        }

        public static bool TrySwitchItem(IInventory inventory, IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}