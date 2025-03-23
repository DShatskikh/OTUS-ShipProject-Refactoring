using System;
using UnityEngine;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class Inventory : IInventory
    {
        public InventoryItem[,] Items { get; set; } = new InventoryItem[5, 5];

        public event Action<InventoryItem> OnItemAdded; 
        public event Action<InventoryItem> OnItemRemoved; 
        public event Action<InventoryItem> OnItemConsumed;
        public event Action<InventoryItem, int, int> OnSlotChange;

        [Inject]
        public void Construct(Vector2Int size) => 
            Items = new InventoryItem[size.x, size.y];

        public void Add(InventoryItem item) => 
            InventoryUseCases.AddItem(this, item);

        public void Remove(InventoryItem item) => 
            InventoryUseCases.TryRemoveItem(this, item);

        public void NotifyAddItem(InventoryItem item) => 
            OnItemAdded?.Invoke(item);
        
        public void NotifyRemoveItem(InventoryItem item) => 
            OnItemRemoved?.Invoke(item);
        
        public void NotifyConsumeItem(InventoryItem item) => 
            OnItemConsumed?.Invoke(item);
        
        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, int x, int y)
        {
            if (previousItem != null)
                OnItemRemoved?.Invoke(previousItem);
            
            OnItemAdded?.Invoke(item);
            OnSlotChange?.Invoke(item, x, y);
        }

        public bool TrySwitchItem(IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition) => 
            InventoryUseCases.TrySwitchItem(this, selectedInventory, position, selectSlotPosition);

        public bool CanSetItem(Vector3Int position, InventoryItem item) => 
            true;

        public void SwitchItem(IInventory selectInventory, Vector3Int position, Vector3Int selectSlotPosition) => 
            InventoryUseCases.SwitchItem(this, selectInventory, position, selectSlotPosition);
    }
}