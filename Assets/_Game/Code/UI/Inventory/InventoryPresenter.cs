using System.Collections.Generic;
using Game.Inventory;
using Game.Systems;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class InventoryPresenter : ITickable
    {
        private readonly InventoryView _view;
        private readonly List<SlotPresenter> _mainSlots = new();
        private readonly List<SlotPresenter> _armorSlots = new();
        private readonly Inventory.Inventory _inventory;
        private readonly ArmorInventory _armorInventory;
        private readonly HandInventory _handInventory;
        private readonly SpeedSystem _speedSystem;
        private readonly HealthSystem _healthSystem;
        
        private Vector3Int _selectSlotPosition = new(-1, -1);
        private IInventory _selectedInventory;
        private SlotPresenter _handSlot;

        public InventoryPresenter(InventoryView view, Inventory.Inventory inventory, ArmorInventory armorInventory, 
            ArmorSystem armorSystem, HandInventory handInventory, AttackSystem attackSystem, SpeedSystem speedSystem,
            HealthSystem healthSystem)
        {
            _view = view;
            _inventory = inventory;
            _armorInventory = armorInventory;
            _handInventory = handInventory;
            _speedSystem = speedSystem;
            _healthSystem = healthSystem;

            armorSystem.OnChange += OnArmorChange;
            attackSystem.OnChange += OnAttackChange;
            speedSystem.OnChange += OnSpeedChange;
            healthSystem.OnChange += OnHealthChange;
            inventory.OnItemAdded += OnItemAdded;

            OnArmorChange(armorSystem.Armor);
            OnAttackChange(attackSystem.Attack);
            OnSpeedChange(speedSystem.Speed);
            OnHealthChange(healthSystem.Health);
            
            InitMainSlots();
            InitArmorSlots();
            InitHandSlot();
        }

        private void InitHandSlot()
        {
            var position = new Vector3Int(0, 0);
            var presenter = new SlotPresenter(_view.GetHandSlot, _handInventory, position);
            presenter.Click += OnClick;
            _handSlot = presenter;
        }

        private void InitArmorSlots()
        {
            int x = 0;

            foreach (var slot in _view.GetArmorSlots)
            {
                var position = new Vector3Int(0, x);
                var presenter = new SlotPresenter(slot, _armorInventory, position);
                presenter.Click += OnClick;
                _armorSlots.Add(presenter);

                x++;
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
        
        private void InitMainSlots()
        {
            int x = 0;
            int y = 0;

            foreach (var slot in _view.GetMainSlots)
            {
                var position = new Vector3Int(x, y);
                var presenter = new SlotPresenter(slot, _inventory, position);
                presenter.Click += OnClick;
                _mainSlots.Add(presenter);

                x++;

                if (x >= _inventory.Items.GetLength(0))
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void OnArmorChange(int value) => 
            _view.SetArmorLabel($"Защита: {value}");

        private void OnClick(SlotPresenter slot, IInventory inventory, Vector3Int position)
        {
            if (CanSelectSlot)
            {
                if (inventory.TrySwitchItem(_selectedInventory, position, _selectSlotPosition))
                {
                    slot.Select(true);
                    _selectSlotPosition = new Vector3Int(-1, -1);
                    _selectedInventory = null;
                    _view.GetMoveItem.ToggleActive(false);
                    _view.GetMoveItem.ToggleLabelActive(false);
                }
            }
            else if (inventory.Items[position.x, position.y] != null)
            {
                _selectSlotPosition = position;
                _selectedInventory = inventory;

                var item = inventory.Items[position.x, position.y];

                if (ItemUseCases.CanFlag(item, ItemFlags.STACKABLE) 
                    && ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent) 
                    && stackableItemComponent.Count > 1)
                {
                    _view.GetMoveItem.ToggleLabelActive(true);
                    _view.GetMoveItem.SetTextLabel(stackableItemComponent.Count.ToString());
                }
                
                _view.GetMoveItem.ToggleActive(true);
                _view.GetMoveItem.SetImage(inventory.Items[position.x, position.y].MetaData.Icon);
                _view.GetMoveItem.SetPosition(Input.mousePosition);
                
                slot.Select(false);
            }
        }

        private bool CanSelectSlot => 
            _selectSlotPosition != new Vector3Int(-1, -1);

        private void OnItemAdded(InventoryItem item)
        {
            
        }

        public void Tick()
        {
            if (_selectSlotPosition != new Vector3Int(-1, -1))
                _view.GetMoveItem.gameObject.transform.position = Input.mousePosition;
        }
    }
}