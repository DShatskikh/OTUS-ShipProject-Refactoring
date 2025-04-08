using Game.Inventory;

namespace Game.UI
{
    public sealed class MoveSlotPresenter
    {
        private readonly MoveItemView _view;
        private readonly Slot _slot;

        public MoveSlotPresenter(MoveItemView view, Slot slot)
        {
            _view = view;
            _slot = slot;
            
            _slot.OnSlotChange += OnChangeItem;
        }

        private void OnChangeItem(InventoryItem item)
        {
            if (_slot.HasItem)
            {
                _view.ToggleActive(true);
                _view.SetImage(_slot.Item.MetaData.Icon);

                if (ItemUseCases.CanFlag(item, ItemFlags.STACKABLE)
                    && ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                    && stackableItemComponent.Count > 1)
                {
                    _view.ToggleLabelActive(true);
                    _view.SetTextLabel($"{stackableItemComponent.Count}");
                }
                else
                {
                    _view.ToggleLabelActive(false);
                }
            }
            else
            {
                _view.ToggleActive(false); 
            } 
        }
    }
}