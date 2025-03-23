using Game.Inventory;
using UnityEngine;

namespace Game.UI
{
    public class SlotPresenterIcon : SlotPresenterBase
    {
        private Sprite _icon;
        
        public SlotPresenterIcon(SlotView view, IInventory inventory, Vector3Int position) : base(view, inventory,
            position)
        {
            _view.ToggleIcon(true);
            _icon = view.GetIcon;
        }
        
        public override void Select(bool value)
        {
            if (!value) 
                _view.ToggleCountLabel(false);
        }
        
        protected override void OnSlotChange(InventoryItem item, int x, int y)
        {
            if (_position != new Vector3Int(x, y))
                return;

            if (item == null)
            {
                _view.SetIcon(_icon);
                _view.ToggleCountLabel(false);
            }
            else
            {
                if (ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                    && stackableItemComponent.Count > 1)
                {
                    _view.ToggleCountLabel(true);
                    _view.SetTextCountLabel(stackableItemComponent.Count.ToString());
                }
                else
                {
                    _view.ToggleCountLabel(false);
                }
                
                _view.SetIcon(item.MetaData.Icon);
            }
        }
    }
}