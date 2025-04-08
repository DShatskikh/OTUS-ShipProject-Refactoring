using System;
using System.Collections.Generic;
using Game.Inventory;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public abstract class SlotPresenterBase
    {
        protected readonly SlotView _view;
        private readonly IInventory _inventory;
        protected readonly Slot _slot;
        
        public event Action<SlotPresenterBase, IInventory, Slot> Click;
        public event Action<SlotPresenterBase, Slot> OnSelectAction;
        public event Action<SlotPresenterBase, Slot> OnDeselectAction;

        public SlotView GetView => _view;
        public IInventory GetInventory => _inventory;
        public Slot GetSlot => _slot;
        
        public SlotPresenterBase(SlotView view, IInventory inventory, Slot slot)
        {
            _view = view;
            _inventory = inventory;
            _slot = slot;
            
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerEnter).callback.AddListener(OnSelect);
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerExit).callback.AddListener(OnDeselect);
            GetTriggerEvent(view.GetTriggerEvent.triggers, EventTriggerType.PointerClick).callback.AddListener(OnClick);
            
            _slot.OnSlotChange += SlotOnOnChangeItem;
        }

        public virtual void Select(bool value)
        {
            _view.ToggleIcon(value);

            if (!value) 
                _view.ToggleCountLabel(false);
        }

        private void OnSelect(BaseEventData arg0)
        {
            _view.ToggleSelect(true);
            OnSelectAction?.Invoke(this, _slot);
        }

        private void OnDeselect(BaseEventData arg0)
        {
            _view.ToggleSelect(false);
            OnDeselectAction?.Invoke(this, _slot);
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

        protected virtual void SlotOnOnChangeItem(InventoryItem item)
        {
            if (_slot.HasItem)
            {
                _view.ToggleIcon(true);
                _view.SetIcon(_slot.Item.MetaData.Icon);

                if (ItemUseCases.CanFlag(item, ItemFlags.STACKABLE)
                    && ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                    && stackableItemComponent.Count > 1)
                {
                    _view.ToggleCountLabel(true);
                    _view.SetTextCountLabel($"{stackableItemComponent.Count}");
                }
                else
                {
                    _view.ToggleCountLabel(false);
                }
            }
            else
            {
                _view.ToggleIcon(false); 
                _view.ToggleCountLabel(false);
            } 
        }

        private void OnClick(BaseEventData arg0)
        {
            Click?.Invoke(this, _inventory, _slot);
        }
    }
}