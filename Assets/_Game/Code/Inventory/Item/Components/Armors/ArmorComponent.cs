using System;
using System.Linq;
using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ArmorComponent : IItemComponent
    {
        public int Armor;
        
        private ArmorSystem _armorSystem;
        private ArmorInventory _armorInventory;

        [Inject]
        public void Construct(ArmorInventory armorInventory, ArmorSystem armorSystem)
        {
            _armorInventory = armorInventory;
            _armorSystem = armorSystem;
            
            _armorInventory.OnItemAdded += OnItemAdded;
            _armorInventory.OnItemRemoved += OnItemRemoved;
        }
        
        public IItemComponent Clone() => 
            new ArmorComponent() { Armor = Armor };

        public void OnItemAdded(InventoryItem item)
        {
            if (item == null)
                return;
            
            var component = item.Components.FirstOrDefault(x => x == this);
            
            if (component != this)
                return;

            _armorSystem.AddArmor(Armor);
        }

        public void OnItemRemoved(InventoryItem item)
        {
            if (item == null)
                return;
            
            var component = item.Components.FirstOrDefault(x => x == this);
            
            if (component != this)
                return;
            
            _armorSystem.RemoveArmor(Armor);
        }
    }
}