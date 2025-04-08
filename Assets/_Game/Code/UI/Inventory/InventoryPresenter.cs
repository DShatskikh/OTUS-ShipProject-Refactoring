using System.Collections.Generic;
using System.Linq;
using Game.Inventory;
using Game.Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.UI
{
    public sealed class InventoryPresenter : ITickable
    {
        private readonly InventoryView _view;
        private readonly MainInventory _mainInventory;
        private readonly ArmorInventory _armorInventory;
        private readonly CraftInventory _craftInventory;
        private readonly List<SlotPresenterBase> _mainSlots = new();
        private readonly List<SlotPresenterBase> _armorSlots = new();
        private readonly List<SlotPresenterBase> _quickAccessSlots = new();
        private readonly List<SlotPresenterBase> _craftSlots = new();
        private Slot _moveSlot;

        private SlotPresenterBase _handSlot;
        private bool IsMoveItem =>
            _moveSlot.HasItem;

        public InventoryPresenter(InventoryView view, MainInventory mainInventory, ArmorInventory armorInventory, 
            CraftInventory craftInventory, DoubleClickDetector doubleClickDetector)
        {
            _view = view;
            _mainInventory = mainInventory;
            _armorInventory = armorInventory;
            _craftInventory = craftInventory;

            doubleClickDetector.DoubleClick += OnDoubleClick;
            
            InitMainSlots();
            InitArmorSlots();
            InitHandSlot();
            InitQuickAccessSlots();
            InitCraftSlots();
            InitMoveSlot();
            InitInfoMessage();
        }

        public void Tick()
        {
            if (IsMoveItem)
                MoveItemSlot();
            
            if (Input.GetMouseButtonUp(0))
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
                    var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                    eventDataCurrentPosition.position = Input.mousePosition;
                    var results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                    if (results.Count > 0)
                    {
                        var clickedObject = results[0].gameObject;
                        ClickRight(clickedObject);
                    }
                }
                else
                {
                    DropOne();
                }
            }
        }

        private void InitMainSlots()
        {
            var x = 0;
            var y = 0;

            foreach (var slot in _view.GetMainSlots)
            {
                var presenter = new SlotPresenter(slot, _mainInventory, _mainInventory.MainSlots[x, y]);
                _mainSlots.Add(presenter);

                x++;

                if (x >= _mainInventory.MainSlots.GetLength(0))
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void InitArmorSlots()
        {
            var y = 0;

            foreach (var slot in _view.GetArmorSlots)
            {
                switch (y)
                {
                    case 0:
                        var helmetPresenter = new SlotPresenterIcon(slot, _armorInventory, _armorInventory.HelmetSlot);
                        _armorSlots.Add(helmetPresenter);
                        break;
                    case 1:
                        var chestplatePresenter = new SlotPresenterIcon(slot, _armorInventory, _armorInventory.ChestplateSlot);
                        _armorSlots.Add(chestplatePresenter);
                        break;
                    case 2:
                        var leggingsPresenter = new SlotPresenterIcon(slot, _armorInventory, _armorInventory.LeggingsSlot);
                        _armorSlots.Add(leggingsPresenter);
                        break;
                    case 3:
                        var bootsPresenter = new SlotPresenterIcon(slot, _armorInventory, _armorInventory.BootsSlot);
                        _armorSlots.Add(bootsPresenter);
                        break;
                }
                
                y++;
            }
        }

        private void InitHandSlot()
        {
            var presenter = new SlotPresenterIcon(_view.GetHandSlot, _armorInventory, _armorInventory.HandSlot);
            _handSlot = presenter;
        }

        private void InitQuickAccessSlots()
        {
            var x = 0;

            foreach (var slot in _view.GetQuickAccessSlots)
            {
                var presenter = new SlotPresenter(slot, _mainInventory, _mainInventory.QuickAccessSlots[x]);
                _quickAccessSlots.Add(presenter);

                x++;
            }
        }

        private void InitCraftSlots()
        {
            var x = 0;
            var y = 0;

            foreach (var slot in _view.GetCraftSlots)
            {
                var presenter = new SlotPresenter(slot, _craftInventory, _craftInventory.Slots[x, y]);
                _craftSlots.Add(presenter);

                x++;

                if (x >= _craftInventory.Slots.GetLength(0))
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void InitMoveSlot()
        {
            _moveSlot = new Slot();
            var moveSlotPresenter = new MoveSlotPresenter(_view.GetMoveItem, _moveSlot);
        }

        private void InitInfoMessage()
        {
            var allSlots = new List<SlotPresenterBase>();
            allSlots.AddRange(_mainSlots);
            allSlots.AddRange(_armorSlots);
            allSlots.AddRange(_quickAccessSlots);
            allSlots.AddRange(_craftSlots);
            allSlots.Add(_handSlot);
            var infoPresenter = new InfoPresenter(_view.GetInfo, allSlots.ToArray());
        }

        private void MoveItemSlot()
        {
            _view.GetMoveItem.gameObject.transform.position = Input.mousePosition;
        }

        private void Drop()
        {
            ItemUseCases.RemoveItem(_moveSlot);
            _view.GetMoveItem.ToggleActive(false);
            _view.GetMoveItem.ToggleLabelActive(false);
        }

        private void DropOne()
        {
            if (IsMoveItem)
            {
                SlotUseCases.TryRemoveOneItem(_moveSlot);
            }
        }

        private void Click(GameObject clickedObject)
        {
            if (!clickedObject.TryGetComponent(out SlotView view))
                return;

            if (!TryGetSlotPresenter(view, out SlotPresenterBase slotPresenter))
                return;
            
            var slot = slotPresenter.GetSlot;
            
            if (SlotUseCases.TrySwitch(slot, _moveSlot))
            {
                MoveItemSlot();
            }
        }

        private void ClickRight(GameObject clickedObject)
        {
            if (!clickedObject.TryGetComponent(out SlotView view))
                return;

            if (!TryGetSlotPresenter(view, out SlotPresenterBase slotPresenter))
                return;
            
            var slot = slotPresenter.GetSlot;

            if (IsMoveItem)
            {
                SlotUseCases.TryPutOneItemDown(slot, _moveSlot);
            }
            else
            {
                SlotUseCases.TakeHalf(slot, _moveSlot);
                MoveItemSlot();
            }
        }

        private void OnDoubleClick()
        {
            var allSlots = new List<Slot>();

            foreach (var slotPresenter in GetAllSlotPresenters()) 
                allSlots.Add(slotPresenter.GetSlot);

            if (IsMoveItem)
                SlotUseCases.PutAllItem(_moveSlot, allSlots);
        }

        private bool TryGetSlotPresenter(SlotView view, out SlotPresenterBase result)
        {
            result = GetAllSlotPresenters().FirstOrDefault(x => x.GetView == view);
            return result != null;
        }

        private List<SlotPresenterBase> GetAllSlotPresenters()
        {
            var allSlots = new List<SlotPresenterBase>();
            allSlots.AddRange(_mainSlots);
            allSlots.AddRange(_armorSlots);
            allSlots.AddRange(_quickAccessSlots);
            allSlots.AddRange(_craftSlots);
            allSlots.Add(_handSlot);

            return allSlots;
        }
    }
}