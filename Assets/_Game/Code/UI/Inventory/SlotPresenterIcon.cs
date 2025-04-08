using Game.Inventory;
using UnityEngine;

namespace Game.UI
{
    public class SlotPresenterIcon : SlotPresenterBase
    {
        private Sprite _icon;
        
        public SlotPresenterIcon(SlotView view, IInventory inventory, Slot slot) : base(view, inventory, slot)
        {
            _view.ToggleIcon(true);
            _icon = view.GetIcon;
        }
        
        public override void Select(bool value)
        {
            if (!value) 
                _view.ToggleCountLabel(false);
        }

        protected override void SlotOnOnChangeItem(InventoryItem item)
        {
            base.SlotOnOnChangeItem(item);

            if (!_slot.HasItem)
            {
                _view.ToggleIcon(true);
                _view.SetIcon(_icon);
            }
        }
    }
}