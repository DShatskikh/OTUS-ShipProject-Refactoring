using System.Linq;

namespace Game.Inventory
{
    public static class ItemUseCases
    {
        public static bool CanFlag(InventoryItem item, ItemFlags flag) => 
            (item.Flags & flag) == flag;
        
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

        public static void RemoveItem(Slot slot)
        {
            slot.Item = null;
        }
    }
}