using System;

namespace Game.Inventory
{
    [Serializable]
    public sealed class BootsEquippableItemComponent : IItemComponent
    {
        public IItemComponent Clone() => 
            new BootsEquippableItemComponent();
    }
}