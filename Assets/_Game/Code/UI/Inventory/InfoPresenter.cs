using Game.Inventory;
using UnityEngine;

namespace Game.UI
{
    public sealed class InfoPresenter
    {
        private readonly InfoView _view;

        public InfoPresenter(InfoView view, SlotPresenterBase[] slots)
        {
            _view = view;
            
            foreach (var slot in slots)
            {
                slot.OnSelectAction += OnSelectAction;
                slot.OnDeselectAction += OnDeselectAction;
                slot.Click += OnClick;
            }
        }

        private void OnSelectAction(SlotPresenterBase presenter, Slot slot)
        {
            if (!slot.HasItem)
                return;
                
            _view.ToggleActivate(true);
            _view.SetNameLabel(slot.Item.MetaData.Name);
            _view.SetDescriptionLabel(slot.Item.MetaData.Description);
            _view.Move(presenter.GetView.transform.position + new Vector3(10, 0));
        }

        private void OnDeselectAction(SlotPresenterBase presenter, Slot slot)
        {
            _view.ToggleActivate(false);
        }

        private void OnClick(SlotPresenterBase presenter, IInventory inventory, Slot slot)
        {
            if (slot.HasItem)
            {
                OnSelectAction(presenter, slot);
            }
            else
            {
                _view.ToggleActivate(false); 
            }
        }
    }
}