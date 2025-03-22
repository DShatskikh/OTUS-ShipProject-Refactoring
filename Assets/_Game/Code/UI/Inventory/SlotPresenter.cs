using System;
using System.Collections.Generic;
using Game.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public sealed class SlotPresenter
    {
        private readonly SlotView _view;
        private readonly IInventory _inventory;
        private readonly Vector3Int _position;

        public event Action<SlotPresenter, IInventory, Vector3Int> Click;

        public SlotPresenter(SlotView view, IInventory inventory, Vector3Int position)
        {
            _view = view;
            _inventory = inventory;
            _position = position;
            
            inventory.OnSlotChange += OnSlotChange;
            
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerEnter).callback.AddListener(OnSelect);
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerExit).callback.AddListener(OnDeselect);
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerClick).callback.AddListener(OnClick);
        }

        public void Select(bool value)
        {
            _view.ToggleIcon(value);

            if (!value) 
                _view.ToggleCountLabel(false);
        }
        
        private void OnSlotChange(InventoryItem item, int x, int y)
        {
            if (_position != new Vector3Int(x, y))
                return;

            if (item == null)
            {
                _view.ToggleIcon(false);
                _view.ToggleCountLabel(false);
            }
            else
            {
                if (ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent))
                {
                    _view.ToggleCountLabel(true);
                    _view.SetTextCountLabel(stackableItemComponent.Count.ToString());
                }
                else
                {
                    _view.ToggleCountLabel(false);
                }
                
                _view.ToggleIcon(true);
                _view.SetIcon(item.MetaData.Icon);
            }
        }

        private void OnSelect(BaseEventData arg0)
        {
            _view.ToggleSelect(true);
        }

        private void OnDeselect(BaseEventData arg0)
        {
            _view.ToggleSelect(false);
        }

        private EventTrigger.Entry GetTriggerEvent(List<EventTrigger.Entry> triggers, EventTriggerType eventTriggerType)
        {
            foreach (var trigger in triggers)
            {
                if (trigger.eventID == eventTriggerType)
                    return trigger;
            }

            return null;
        }

        private void OnClick(BaseEventData arg0)
        {
            Click?.Invoke(this, _inventory, _position);
            Debug.Log("Click");
        }
    }
}