using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HelmetComponent : IItemComponent
    {
        public Sprite PlayerSprite;
        
        public IItemComponent Clone() => 
            new HelmetComponent() { PlayerSprite = PlayerSprite };
    }
}