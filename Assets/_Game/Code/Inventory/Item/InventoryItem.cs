using System;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public sealed class InventoryItem
    {
        public string Id;
        public InventoryItemMetaData MetaData;
        public ItemFlags Flags;
        
        [SerializeReference]
        public IItemComponent[] Components;

        public InventoryItem(string id, InventoryItemMetaData metaData, ItemFlags flags, IItemComponent[] components)
        {
            Id = id;
            MetaData = metaData;
            Flags = flags;
            Components = new IItemComponent[components.Length];

            for (int i = 0; i < components.Length; i++) 
                Components[i] = components[i].Clone();
        }
        
        public InventoryItem Clone() => 
            new(Id, MetaData.Clone(), Flags, Components);

        public bool TryGetComponent<T>(out T component) where T : IItemComponent
        {
            foreach (var itemComponent in Components)
            {
                if (itemComponent is T result)
                {
                    component = result;
                    return true;
                }
            }

            component = default;
            return false;
        }
    }
}
