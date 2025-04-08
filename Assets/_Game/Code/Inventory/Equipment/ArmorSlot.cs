using System;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ArmorSlot : Slot
    {
        private readonly ArmorType _armorType;

        public ArmorSlot(ArmorType armorType)
        {
            _armorType = armorType;
        }
        
        public override bool CanMoveItem(InventoryItem item)
        {
            if (item == null)
                return true;
            
            if (ItemUseCases.TryGetComponent(item, out ArmorComponent armorComponent))
                return armorComponent.ArmorType == _armorType;

            return false;
        }
    }
}