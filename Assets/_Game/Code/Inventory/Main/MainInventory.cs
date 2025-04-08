using System;
using UnityEngine;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class MainInventory : IInventory
    {
        public Slot[,] MainSlots = new Slot[5, 5];
        public Slot[] QuickAccessSlots = new Slot[9];
        
        public event Action<InventoryItem> OnItemAdded; 
        public event Action<InventoryItem> OnItemRemoved; 
        public event Action<InventoryItem> OnItemConsumed;
        public event Action<InventoryItem, Slot> OnSlotChange;

        [Inject]
        public void Construct(Vector2Int size)
        {
            MainSlots = new Slot[size.x, size.y];

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    MainSlots[x, y] = new Slot();
                }  
            }

            for (int i = 0; i < QuickAccessSlots.Length; i++)
            {
                QuickAccessSlots[i] = new Slot();
            }
        }

        public void Add(InventoryItem item) => 
            InventoryUseCases.TryAddItem(this, item);

        public void NotifyAddItem(InventoryItem item) => 
            OnItemAdded?.Invoke(item);

        public void NotifyRemoveItem(InventoryItem item) => 
            OnItemRemoved?.Invoke(item);

        public void NotifyConsumeItem(InventoryItem item) => 
            OnItemConsumed?.Invoke(item);

        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, Slot slot)
        {
            if (previousItem != null)
                OnItemRemoved?.Invoke(previousItem);
            
            OnItemAdded?.Invoke(item);
            OnSlotChange?.Invoke(item, slot);
        }
    }
}