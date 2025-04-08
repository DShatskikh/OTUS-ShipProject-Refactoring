using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ArmorInventory : IInventory
    {
        public ArmorSlot HelmetSlot = new(ArmorType.Helmet);
        public ArmorSlot ChestplateSlot = new(ArmorType.Chestplate);
        public ArmorSlot LeggingsSlot = new(ArmorType.Leggings);
        public ArmorSlot BootsSlot = new(ArmorType.Boots);
        public Slot HandSlot = new();

        public ArmorSlot[] GetArmorSlots => new[]
        {
            HelmetSlot,
            ChestplateSlot,
            LeggingsSlot,
            BootsSlot
        };

        public event Action<InventoryItem, Slot> OnSlotChange;
        public event Action<InventoryItem> OnItemAdded;
        public event Action<InventoryItem> OnItemRemoved;

        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, Slot slot)
        {
            throw new NotImplementedException();
        }

        public bool TrySwitchItem(IInventory selectedInventory, Vector3Int position, Vector3Int selectSlotPosition) => 
            InventoryUseCases.TrySwitchItem(this, selectedInventory, position, selectSlotPosition);
    }
}