using UnityEngine;

namespace Game.Inventory
{
    public static class InventoryUseCases
    {
        public static void AddItem(Inventory inventory, InventoryItem item)
        {
            var isExit = false;
            var isNotAdd = false;
            
            for (int y = 0; y < inventory.Items.GetLength(1); y++)
            {
                if (isExit)
                    break;
                
                for (int x = 0; x < inventory.Items.GetLength(0); x++)
                {
                    var currentItem = inventory.Items[x, y];
                    
                    if (currentItem == null)
                        continue;
                    
                    if (ItemUseCases.CanFlag(currentItem, ItemFlags.STACKABLE) 
                        && ItemUseCases.TryGetComponent<StackableItemComponent>(currentItem, out var currentStackableItemComponent)
                        && ItemUseCases.TryGetComponent<StackableItemComponent>(item, out var stackableItemComponent)
                        && currentItem.Id == item.Id)
                    {
                        var currentCount = currentStackableItemComponent.Count;
                        var currentMaxCount = currentStackableItemComponent.MaxCount;

                        var stackableItemCount = stackableItemComponent.Count;
                        
                        if (currentCount + stackableItemCount <= currentMaxCount)
                        {
                            currentStackableItemComponent.Count += stackableItemCount;
                            stackableItemComponent.Count = 0;
                            inventory.NotifyChangeSlot(currentItem, null, x, y);
                            isExit = true;
                            isNotAdd = true;
                            break; 
                        }
                        else
                        {
                            stackableItemComponent.Count -= currentMaxCount - currentCount;
                            currentStackableItemComponent.Count = currentMaxCount; 
                            inventory.NotifyChangeSlot(currentItem,  null, x, y);
                        }
                    }
                }
            }

            if (!isNotAdd)
            {
                isExit = false;
                
                for (int y = 0; y < inventory.Items.GetLength(1); y++)
                {
                    if (isExit)
                        break;
                
                    for (int x = 0; x < inventory.Items.GetLength(0); x++)
                    {
                        var currentItem = inventory.Items[x, y];
                    
                        if (currentItem != null)
                            continue;

                        inventory.Items[x, y] = item;
                        inventory.NotifyChangeSlot(item, null, x, y);
                        isExit = true;
                        break;
                    }
                }
            }

            inventory.NotifyAddItem(item);
        }

        public static bool TryRemoveItem(IInventory inventory, InventoryItem item, int removeCount = 1)
        {
            for (int y = 0; y < inventory.Items.GetLength(1); y++)
            {
                for (int x = 0; x < inventory.Items.GetLength(0); x++)
                {
                    if (inventory.Items[x, y] != item)
                        continue;

                    var count = ItemUseCases.GetCount(item);

                    count -= removeCount;
                    
                    if (count <= 0)
                    {
                        inventory.Items[x, y] = null;
                        inventory.NotifyChangeSlot(null, item, x, y);
                    }
                    else
                    {
                        ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent);
                        stackableItemComponent.Count -= removeCount;
                    }
                }
            }

            return false;
        }

        public static void ConsumeItem(Inventory inventory, InventoryItem item)
        {
            //RemoveItem(inventory, item);
            inventory.NotifyConsumeItem(item);
        }

        public static void SwitchItem(IInventory inventory, IInventory selectInventory, Vector3Int position, Vector3Int selectSlotPosition)
        {
            var item = inventory.Items[position.x, position.y];
            var selectItem = selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y];
            
            if (item != null 
                && selectItem != null
                && item.Id == selectItem.Id 
                && item.TryGetComponent(out StackableItemComponent stackableComponent) 
                && selectItem.TryGetComponent(out StackableItemComponent selectStackableComponent))
            {
                stackableComponent.Count += selectStackableComponent.Count;
                selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y] = null;
                
                inventory.NotifyChangeSlot(inventory.Items[position.x, position.y], inventory.Items[position.x, position.y], position.x, position.y);
                selectInventory.NotifyChangeSlot(null, selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y], selectSlotPosition.x, selectSlotPosition.y);
            }
            else
            {
                (inventory.Items[position.x, position.y], selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y])
                    = (selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y], inventory.Items[position.x, position.y]);
                
                inventory.NotifyChangeSlot(inventory.Items[position.x, position.y], selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y], position.x, position.y);
                selectInventory.NotifyChangeSlot(selectInventory.Items[selectSlotPosition.x, selectSlotPosition.y], inventory.Items[position.x, position.y], selectSlotPosition.x, selectSlotPosition.y);
            }
        }

        public static bool TrySwitchItem(IInventory inventory, IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition)
        {
            var item = inventory.Items[position.x, position.y];
            var selectItem = selectedInventory.Items[selectSlotPosition.x, selectSlotPosition.y];

            if (inventory.CanSetItem(position, selectItem) && selectedInventory.CanSetItem(selectSlotPosition, item))
            {
                SwitchItem(inventory, selectedInventory, position, selectSlotPosition);
                return true;
            }
            
            return false;
        }
    }
}