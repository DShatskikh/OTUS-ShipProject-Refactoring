using System;

namespace Game.Inventory
{
    [Serializable]
    public sealed class LeggingsEquippableItemComponent : IItemComponent
    {
        public IItemComponent Clone() => 
            new LeggingsEquippableItemComponent();
    }
}