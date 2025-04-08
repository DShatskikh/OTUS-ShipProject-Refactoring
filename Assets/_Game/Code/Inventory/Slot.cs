using System;

namespace Game.Inventory
{
    [Serializable]
    public class Slot
    {
        public InventoryItem Item;
        public bool HasItem => Item != null;
        public event Action<InventoryItem> OnSlotChange;
        public event Action<InventoryItem> OnItemAdded;
        public event Action<InventoryItem> OnItemRemoved;

        public void NotifyChange(InventoryItem item, InventoryItem previousItem)
        {
            if (previousItem != null)
                OnItemRemoved?.Invoke(previousItem);
            
            if (item != null)
                OnItemAdded?.Invoke(item);
            
            OnSlotChange?.Invoke(item);
        }

        public virtual bool CanMoveItem(InventoryItem item)
        {
            return true;
        }
    }
}