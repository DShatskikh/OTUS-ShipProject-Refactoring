using System;
using Zenject;

namespace Game.Inventory
{
    public class CraftInventory : IInventory
    {
        private const int SizeX = 2;
        private const int SizeY = 2;
        
        public Slot[,] Slots { get; set; } = new Slot[SizeX, SizeY];
        public Slot ResultSlot { get; set; } = new();
        
        public event Action<InventoryItem, Slot> OnSlotChange;
        
        [Inject]
        public void Construct()
        {
            Slots = new Slot[SizeX, SizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    Slots[x, y] = new Slot();
                }  
            }
        }
        
        public void NotifyChangeSlot(InventoryItem item, InventoryItem previousItem, Slot slot) => 
            OnSlotChange?.Invoke(item, slot);
    }
}