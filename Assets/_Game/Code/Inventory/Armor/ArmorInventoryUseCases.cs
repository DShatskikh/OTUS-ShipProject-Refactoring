namespace Game.Inventory
{
    public static class ArmorInventoryUseCases
    {
        public static bool IsCanSetHelmetItem(ArmorInventory armorInventory, InventoryItem item)
        {
            if (armorInventory.Items[0, 0] == item || item == null)
                return true;
            
            if (ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE) 
                && ItemUseCases.TryGetComponent(item, out HelmetComponent headEquippableItemComponent))
                return true;

            return false;
        }
        
        public static bool IsCanSetChestplateItem(ArmorInventory armorInventory, InventoryItem item)
        {
            if (armorInventory.Items[0, 1] == item || item == null)
                return true;
            
            if (ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE) 
                && ItemUseCases.TryGetComponent(item, out ChestplateComponent chestplateEquippableItemComponent))
                return true;

            return false;
        }
        
        public static bool IsCanSetLeggingsItem(ArmorInventory armorInventory, InventoryItem item)
        {
            if (armorInventory.Items[0, 2] == item || item == null)
                return true;
            
            if (ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE) 
                && ItemUseCases.TryGetComponent(item, out LeggingsComponent leggingsEquippableItemComponent))
                return true;

            return false;
        }
        
        public static bool IsCanSetBootsItem(ArmorInventory armorInventory, InventoryItem item)
        {
            if (armorInventory.Items[0, 3] == item || item == null)
                return true;
            
            if (ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE) 
                && ItemUseCases.TryGetComponent(item, out BootsComponent bootsEquippableItemComponent))
                return true;

            return false;
        }
    }
}