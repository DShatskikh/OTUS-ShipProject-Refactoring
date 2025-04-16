using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Project.Code
{
    public sealed class CraftTable : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _countLabel;
        
        [SerializeField]
        private List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
            _countLabel.text = _items.Count.ToString();
        }
    }
}