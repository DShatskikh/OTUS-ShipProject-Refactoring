using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class InventoryItemMetaData
    {
        public string Name;
        [TextArea]
        public string Description;
        public Sprite Icon;

        public InventoryItemMetaData(string name, string description, Sprite icon)
        {
            Name = name;
            Description = description;
            Icon = icon;
        }
        
        public InventoryItemMetaData Clone() => 
            new(Name, Description, Icon);
    }
}