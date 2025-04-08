using UnityEngine;

namespace Game.Inventory
{
    public static class InventoryUseCases
    {
        public static bool TryAddItem(MainInventory inventory, InventoryItem item)
        {
            foreach (var slot in inventory.QuickAccessSlots)
            {
                if (SlotUseCases.TryAdd(slot, item, out int remains))
                {
                    if (remains == 0)
                        return true;
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
                            return true;
                    }
                } 
            }

            Debug.Log("Предмет не поместился");
            return false;
        }
    }
}