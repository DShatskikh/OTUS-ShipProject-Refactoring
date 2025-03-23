using System.Collections.Generic;
using System.Linq;
using Game.Inventory;
using Game.Systems;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.UI
{
    public sealed class InventoryPresenter : ITickable
    {
        private readonly InventoryView _view;
        private readonly List<SlotPresenterBase> _mainSlots = new();
        private readonly List<SlotPresenterBase> _armorSlots = new();
        private readonly List<SlotPresenterBase> _quickAccessSlots = new();
        private readonly List<SlotPresenterBase> _craftSlots = new();
        private readonly Inventory.Inventory _inventory;
        private readonly ArmorInventory _armorInventory;
        private readonly HandInventory _handInventory;
        private readonly SpeedSystem _speedSystem;
        private readonly HealthSystem _healthSystem;
        private readonly QuickAccessInventory _quickAccessInventory;
        private readonly CraftInventory _craftInventory;
        private readonly MoveItemInventory _moveItemInventory;

        private SlotPresenterBase _handSlot;
        private bool IsMoveItem => 
            _moveItemInventory.Items[0, 0] != null;

        public InventoryPresenter(InventoryView view, Inventory.Inventory inventory, ArmorInventory armorInventory, 
            ArmorSystem armorSystem, HandInventory handInventory, AttackSystem attackSystem, SpeedSystem speedSystem,
            HealthSystem healthSystem, QuickAccessInventory quickAccessInventory, CraftInventory craftInventory, 
            MoveItemInventory moveItemInventory)
        {
            _view = view;
            _inventory = inventory;
            _armorInventory = armorInventory;
            _handInventory = handInventory;
            _quickAccessInventory = quickAccessInventory;
            _craftInventory = craftInventory;
            _moveItemInventory = moveItemInventory;
            _speedSystem = speedSystem;
            _healthSystem = healthSystem;

            armorSystem.OnChange += OnArmorChange;
            attackSystem.OnChange += OnAttackChange;
            speedSystem.OnChange += OnSpeedChange;
            healthSystem.OnChange += OnHealthChange;

            OnArmorChange(armorSystem.Armor);
            OnAttackChange(attackSystem.Attack);
            OnSpeedChange(speedSystem.Speed);
            OnHealthChange(healthSystem.Health);
            
            InitMainSlots();
            InitArmorSlots();
            InitHandSlot();
            InitQuickAccessSlots();
            InitCraftSlots();
        }

        private void InitCraftSlots()
        {
            int x = 0;
            int y = 0;

            foreach (var slot in _view.GetCraftSlots)
            {
                var position = new Vector3Int(x, y);
                var presenter = new SlotPresenter(slot, _craftInventory, position);
                _craftSlots.Add(presenter);

                x++;

                if (x >= _craftInventory.Items.GetLength(0))
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void InitQuickAccessSlots()
        {
            int x = 0;

            foreach (var slot in _view.GetQuickAccessSlots)
            {
                var position = new Vector3Int(x, 0);
                var presenter = new SlotPresenter(slot, _quickAccessInventory, position);
                _quickAccessSlots.Add(presenter);

                x++;
            }
        }

        private void InitHandSlot()
        {
            var position = new Vector3Int(0, 0);
            var presenter = new SlotPresenterIcon(_view.GetHandSlot, _handInventory, position);
            _handSlot = presenter;
        }

        private void InitArmorSlots()
        {
            int y = 0;

            foreach (var slot in _view.GetArmorSlots)
            {
                var position = new Vector3Int(0, y);
                var presenter = new SlotPresenterIcon(slot, _armorInventory, position);
                _armorSlots.Add(presenter);

                y++;
            }
        }

        private void InitMainSlots()
        {
            int x = 0;
            int y = 0;

            foreach (var slot in _view.GetMainSlots)
            {
                var position = new Vector3Int(x, y);
                var presenter = new SlotPresenter(slot, _inventory, position);
                _mainSlots.Add(presenter);

                x++;

                if (x >= _inventory.Items.GetLength(0))
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void OnAttackChange(int value)
        {
            _view.SetAttackLabel($"Атака: {value}");
        }

        private void OnHealthChange(int value)
        {
            _view.SetHealthLabel($"Здоровье: {value}");
        }

        private void OnSpeedChange(int value)
        {
            _view.SetSpeedLabel($"Скорость: {value}");
        }

        private void OnArmorChange(int value) => 
            _view.SetArmorLabel($"Защита: {value}");

        public void Tick()
        {
            if (IsMoveItem)
                _view.GetMoveItem.gameObject.transform.position = Input.mousePosition;
            
            if (Input.GetMouseButtonDown(0))
            {
                var current = EventSystem.current;
                
                if (current.IsPointerOverGameObject())
                {
                    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                    eventDataCurrentPosition.position = Input.mousePosition;
                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                    if (results.Count > 0)
                    {
                        GameObject clickedObject = results[0].gameObject;
                        Click(clickedObject);
                    }
                }
                else
                {
                    Drop();
                }
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                var current = EventSystem.current;
                
                if (current.IsPointerOverGameObject())
                {
                    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                    eventDataCurrentPosition.position = Input.mousePosition;
                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                    if (results.Count > 0)
                    {
                        GameObject clickedObject = results[0].gameObject;
                        ClickRight(clickedObject);
                    }
                }
                else
                {
                    DropOne();
                }
            }
        }

        private void Drop()
        {
            _moveItemInventory.RemoveItem();
            _view.GetMoveItem.ToggleActive(false);
            _view.GetMoveItem.ToggleLabelActive(false);
        }

        private void DropOne()
        {
            var item = _moveItemInventory.Items[0, 0];
            
            if (item != null)
            {
                InventoryUseCases.TryRemoveItem(_moveItemInventory, item, 1);

                item = _moveItemInventory.Items[0, 0];
                
                if (item != null)
                {
                    if (ItemUseCases.GetCount(item) > 1)
                    {
                        _view.GetMoveItem.SetTextLabel(ItemUseCases.GetCount(item).ToString());
                    }
                    else
                    {
                        _view.GetMoveItem.ToggleLabelActive(false);
                    }
                }
                else
                {
                    _view.GetMoveItem.ToggleActive(false);
                }
            }
        }

        private void ClickRight(GameObject clickedObject)
        {
            if (!clickedObject.TryGetComponent(out SlotView view))
                return;

            if (!TryGetSlotPresenter(view, out SlotPresenterBase slot))
                return;
            
            var inventory = slot.GetInventory;
            var position = slot.GetPosition;
            var item = inventory.Items[position.x, position.y];
            
            if (IsMoveItem)
            {
                if (ItemUseCases.TryAddOne(inventory, position, _moveItemInventory, Vector3Int.zero))
                {
                    if (!IsMoveItem)
                    {
                        _view.GetMoveItem.ToggleActive(false);
                    }
                    else
                    {
                        var count = ItemUseCases.GetCount(inventory.Items[position.x, position.y]);

                        if (count > 1)
                        {
                            _view.GetMoveItem.SetTextLabel(count.ToString());
                        }
                        else
                        {
                            _view.GetMoveItem.ToggleLabelActive(false);
                        }
                    }
                }
            }
            else
            {
                if (ItemUseCases.TryAddOne(_moveItemInventory, Vector3Int.zero, inventory, position))
                {
                    if (!IsMoveItem)
                    {
                        _view.GetMoveItem.ToggleActive(false);
                    }
                    else
                    {
                        var count = ItemUseCases.GetCount(inventory.Items[position.x, position.y]);

                        if (count > 1)
                        {
                            _view.GetMoveItem.SetTextLabel(count.ToString());
                        }
                        else
                        {
                            _view.GetMoveItem.ToggleLabelActive(false);
                        }
                    }
                }
            }
        }

        private void Click(GameObject clickedObject)
        {
            if (!clickedObject.TryGetComponent(out SlotView view))
                return;

            if (!TryGetSlotPresenter(view, out SlotPresenterBase slot))
                return;
            
            var inventory = slot.GetInventory;
            var position = slot.GetPosition;
            var item = inventory.Items[position.x, position.y];
            
            if (IsMoveItem && inventory.TrySwitchItem(_moveItemInventory, position, Vector3Int.zero))
            {
                slot.Select(true);

                if (_moveItemInventory.Items[0, 0] == null)
                {
                    _view.GetMoveItem.ToggleActive(false);
                    _view.GetMoveItem.ToggleLabelActive(false);
                }
                else
                {
                    _view.GetMoveItem.SetImage(item.MetaData.Icon);
                    
                    if (ItemUseCases.CanFlag(item, ItemFlags.STACKABLE) 
                        && ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                        && stackableItemComponent.Count > 1)
                    {
                        _view.GetMoveItem.ToggleLabelActive(true);
                        _view.GetMoveItem.SetTextLabel(stackableItemComponent.Count.ToString());
                    }
                    else
                    {
                        _view.GetMoveItem.ToggleLabelActive(false);
                    }
                }
            }
            else if (item != null)
            {
                _moveItemInventory.TrySwitchItem(inventory, Vector3Int.zero, position);
                
                if (ItemUseCases.CanFlag(item, ItemFlags.STACKABLE) 
                    && ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                    && stackableItemComponent.Count > 1)
                {
                    _view.GetMoveItem.ToggleLabelActive(true);
                    _view.GetMoveItem.SetTextLabel(stackableItemComponent.Count.ToString());
                }
                
                _view.GetMoveItem.ToggleActive(true);
                _view.GetMoveItem.SetImage(_moveItemInventory.Items[0, 0].MetaData.Icon);
                _view.GetMoveItem.SetPosition(Input.mousePosition);
                
                slot.Select(false);
            }
        }

        private bool TryGetSlotPresenter(SlotView view, out SlotPresenterBase result)
        {
            var allSlots = new List<SlotPresenterBase>();
            allSlots.AddRange(_mainSlots);
            allSlots.AddRange(_armorSlots);
            allSlots.AddRange(_quickAccessSlots);
            allSlots.AddRange(_craftSlots);
            allSlots.Add(_handSlot);

            result = allSlots.FirstOrDefault(x => x.GetView == view);
            return result != null;
        }
    }
}