using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        private TMP_Text _armorLabel;
        
        [SerializeField]
        private TMP_Text _attackLabel;
        
        [SerializeField]
        private TMP_Text _speedLabel;
        
        [SerializeField]
        private TMP_Text _healthLabel;
        
        public IEnumerable<SlotView> GetMainSlots => _mainSlots;
        public IEnumerable<SlotView> GetArmorSlots => _armorSlots;
        public IEnumerable<SlotView> GetQuickAccessSlots => _quickAccessSlots;
        public IEnumerable<SlotView> GetCraftSlots => _craftSlots;
        public SlotView GetHandSlot => _handSlot;
        public MoveItemView GetMoveItem => _moveItem;

        public void SetArmorLabel(string value) => 
            _armorLabel.text = value;
        
        public void SetAttackLabel(string value) => 
            _attackLabel.text = value;
        
        public void SetSpeedLabel(string value) => 
            _speedLabel.text = value;
        
        public void SetHealthLabel(string value) => 
            _healthLabel.text = value;
    }
}