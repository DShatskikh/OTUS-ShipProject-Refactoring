using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ChestplateComponent : IItemComponent
    {
        public Sprite PlayerSprite;

        public IItemComponent Clone() => 
            new ChestplateComponent() { PlayerSprite = PlayerSprite };
    }
}