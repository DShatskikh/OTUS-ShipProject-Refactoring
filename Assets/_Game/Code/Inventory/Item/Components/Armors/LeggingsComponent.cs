using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class LeggingsComponent : IItemComponent
    {
        public Sprite PlayerSprite;

        public IItemComponent Clone() => 
            new LeggingsComponent() { PlayerSprite = PlayerSprite };
    }
}