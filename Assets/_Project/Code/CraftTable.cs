using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code
{
    public sealed class CraftTable : MonoBehaviour
    {
        [SerializeField]
        private List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}