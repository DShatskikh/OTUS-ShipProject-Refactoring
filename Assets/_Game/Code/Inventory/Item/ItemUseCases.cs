using System.Linq;
using UnityEngine;

namespace Game.Inventory
{
    public static class ItemUseCases
    {
        public static bool CanFlag(InventoryItem item, ItemFlags flag) => 
            (item.Flags & flag) == flag;

        public static bool CanConsume(InventoryItem item) => 
            CanFlag(item, ItemFlags.CONSUMABLE);

        public static bool TryGetComponent<T>(InventoryItem item, out T component) where T : IItemComponent
        {
            component = default;

            if (item == null)
                return false;

            if (item.Components == null)
                return false;
            
            foreach (var itemComponent in item.Components)
            {
                if (itemComponent.GetType() == typeof(T))
                {
                    component = (T)itemComponent;
                    return true;
                }
            }

            return false;
        }

        public static bool CanComponent(InventoryItem item, IItemComponent component)
        {
            if (item == null)
                return false;
            
            if (component != item.Components.FirstOrDefault(x => x == component))
                return false;

            return true;
        }
        
        public static int GetCount(InventoryItem item)
        {
            if (!CanFlag(item, ItemFlags.STACKABLE))
                return 1;
            
            if (!TryGetComponent(item, out StackableItemComponent stackableComponent))
                return 1;

            return stackableComponent.Count;
        }

        public static bool TryAddOne(IInventory inventory, Vector3Int position, IInventory addedInventory, Vector3Int addedPosition)
        {
            if (!inventory.CanSetItem(position, addedInventory.Items[addedPosition.x, addedPosition.y]) 
                || !addedInventory.CanSetItem(addedPosition, inventory.Items[position.x, position.y]))
                return false;

            if (inventory.Items[position.x, position.y] == null &&
                addedInventory.Items[addedPosition.x, addedPosition.y] != null)
            {
                inventory.Items[position.x, position.y] =
                    addedInventory.Items[addedPosition.x, addedPosition.y].Clone();
                
                if (inventory.Items[position.x, position.y]
                    .TryGetComponent(out StackableItemComponent stackableItemComponent))
                {
                    stackableItemComponent.Count = 1;
                }

                if (addedInventory.Items[addedPosition.x, addedPosition.y]
                    .TryGetComponent(out StackableItemComponent addedstackableComponent) && addedstackableComponent.Count > 1)
                {
                    addedstackableComponent.Count -= 1;
                }
                else
                {
                    addedInventory.NotifyChangeSlot(addedInventory.Items[addedPosition.x, addedPosition.y], 
                        addedInventory.Items[addedPosition.x, addedPosition.y], addedPosition.x, addedPosition.y);
                    addedInventory.Items[addedPosition.x, addedPosition.y] = null;
                }
                
                inventory.NotifyChangeSlot(inventory.Items[position.x, position.y], null, position.x, position.y);

                return true;
            }
            
            // if (item.Id != addedItem.Id)
            //     return false;
            //
            // if (!CanFlag(item, ItemFlags.STACKABLE))
            //     return false;
            //
            // var count = GetCount(addedItem);
            //
            // if (TryGetComponent(item, out StackableItemComponent stackableItemComponent))
            // {
            //     stackableItemComponent.Count += count;
            //     return true;
            // }

            return false;
        }
    }
}