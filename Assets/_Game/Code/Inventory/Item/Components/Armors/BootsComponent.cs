using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class BootsComponent : IItemComponent
    {
        public Sprite PlayerSprite;
        
        public IItemComponent Clone() => 
            new BootsComponent() { PlayerSprite = PlayerSprite };
    }
}