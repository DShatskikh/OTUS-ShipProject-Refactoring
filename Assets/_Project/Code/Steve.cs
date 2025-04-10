using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code
{
    public sealed class Steve : MonoBehaviour
    {
        private const int SIZE_INVENTORY = 2;
        
        [SerializeField]
        private List<Item> _items = new();
        
        public List<Item> GetItems => _items;
        
        public bool GetIsFullInventory =>
            _items.Count == SIZE_INVENTORY;
        
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.ID == id)
                {
                    _items.Remove(item);
                    return;
                }
            }
        }

        public void RemoveAllItems()
        {
            _items = new List<Item>();
        }
    }
}