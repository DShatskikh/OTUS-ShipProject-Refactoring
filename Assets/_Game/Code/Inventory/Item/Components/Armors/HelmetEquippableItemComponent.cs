using System;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HelmetEquippableItemComponent : IItemComponent
    {
        public IItemComponent Clone() => 
            new HelmetEquippableItemComponent();
    }
}