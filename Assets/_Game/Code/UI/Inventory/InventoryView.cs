using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private SlotView[] _mainSlots;

        [SerializeField]
        private SlotView[] _armorSlots;

        [SerializeField]
        private SlotView[] _quickAccessSlots;

        [SerializeField]
        private SlotView[] _craftSlots;

        [SerializeField]
        private SlotView _handSlot;
        
        [SerializeField]
        private MoveItemView _moveItem;

        [SerializeField]
        private InfoView _infoView;

        public IEnumerable<SlotView> GetMainSlots => _mainSlots;
        public IEnumerable<SlotView> GetArmorSlots => _armorSlots;
        public IEnumerable<SlotView> GetQuickAccessSlots => _quickAccessSlots;
        public IEnumerable<SlotView> GetCraftSlots => _craftSlots;
        public SlotView GetHandSlot => _handSlot;
        public MoveItemView GetMoveItem => _moveItem;
        public InfoView GetInfo => _infoView;
    }
}