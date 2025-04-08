using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class ArmorComponent : IItemComponent
    {
        public int Armor;
        public ArmorType ArmorType;
        public Sprite PlayerSprite;

        public IItemComponent Clone() => 
            new ArmorComponent() { Armor = Armor, ArmorType = ArmorType, PlayerSprite = PlayerSprite };
    }

    public enum ArmorType
    {
        Helmet,
        Chestplate,
        Leggings,
        Boots
    }
}