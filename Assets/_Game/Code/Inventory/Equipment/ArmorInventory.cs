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
            if (previousItem != null)
                OnItemRemoved?.Invoke(previousItem);
            
            OnItemAdded?.Invoke(item);
            OnSlotChange?.Invoke(item, slot);
        }

        public bool TryAdd(Slot slot)
        {
            var item = slot.Item;
            
            if (ItemUseCases.TryGetComponent(item, out ArmorComponent armorComponent))
            {
                switch (armorComponent.ArmorType)
                {
                    case ArmorType.Helmet:
                        if (HelmetSlot.HasItem)
                            return false;
                        
                        HelmetSlot.Item = item;
                        slot.Item = null;
                        HelmetSlot.NotifyChange(item, null);
                        slot.NotifyChange(null, item);
                        return true;
                    case ArmorType.Chestplate:
                        if (ChestplateSlot.HasItem)
                            return false;
                        
                        ChestplateSlot.Item = item;
                        slot.Item = null;
                        ChestplateSlot.NotifyChange(item, null);
                        slot.NotifyChange(null, item);
                        return true;
                    case ArmorType.Leggings:
                        if (LeggingsSlot.HasItem)
                            return false;
                        
                        LeggingsSlot.Item = item;
                        slot.Item = null;
                        LeggingsSlot.NotifyChange(item, null);
                        slot.NotifyChange(null, item);
                        return true;
                    case ArmorType.Boots:
                        if (BootsSlot.HasItem)
                            return false;
                        
                        BootsSlot.Item = item;
                        slot.Item = null;
                        BootsSlot.NotifyChange(item, null);
                        slot.NotifyChange(null, item);
                        return true;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            return false;
        }
    }
}