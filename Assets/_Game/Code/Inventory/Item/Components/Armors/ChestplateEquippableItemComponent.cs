using System;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ChestplateEquippableItemComponent : IItemComponent
    {
        public IItemComponent Clone() => 
            new ChestplateEquippableItemComponent();
    }
}