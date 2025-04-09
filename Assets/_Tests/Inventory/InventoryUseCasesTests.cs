using Game.Inventory;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class InventoryUseCasesTests
    {
        // Добавляем предмет в пустой инвентарь
        [Test]
        public void WhenAddItemToMainInventoryEmpty_ThenItem()
        {
            // Arrange:
            var mainInventory = new MainInventory();
            var size = new Vector2Int(9, 3);
            mainInventory.Construct(size);

            var item = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { });

            // Act:
            InventoryUseCases.TryAddItem(mainInventory, item);

            // Assert:
            var result = mainInventory.QuickAccessSlots[0].Item;
            Assert.AreEqual(result.Id, item.Id);
        }
        
        // Добавляем предмет в инвентарь где уже есть предмет
        [Test]
        public void WhenAddItemToMainInventoryNotEmpty_ThenItem()
        {
            // Arrange:
            var mainInventory = new MainInventory();
            var size = new Vector2Int(9, 3);
            mainInventory.Construct(size);

            var item = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { });

            // Act:
            InventoryUseCases.TryAddItem(mainInventory, item);
            InventoryUseCases.TryAddItem(mainInventory, item);

            // Assert:
            var result = mainInventory.QuickAccessSlots[1].Item.Id;
            Assert.AreEqual(result, item.Id);
        }
        
        // Добавляем предмет в инвентарь где уже есть предмет
        [Test]
        public void WhenAddItemToMainInventoryFull_ThenNotAdd()
        {
            // Arrange:
            var mainInventory = new MainInventory();
            var size = new Vector2Int(9, 3);
            mainInventory.Construct(size);

            var item = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { });

            foreach (var slot in mainInventory.MainSlots) 
                slot.Item = item.Clone();
            
            foreach (var slot in mainInventory.QuickAccessSlots) 
                slot.Item = item.Clone();

            // Act:
            var result = InventoryUseCases.TryAddItem(mainInventory, item.Clone());

            // Assert:
            Assert.IsFalse(result);
        }
        
        // Добавляем стакаемый предмет в инвентарь где уже есть такой же предмет
        [Test]
        public void WhenAddStackableItemToMainInventory_Then2()
        {
            // Arrange:
            var mainInventory = new MainInventory();
            var size = new Vector2Int(9, 3);
            mainInventory.Construct(size);
            
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent()
                {
                    Count = 1,
                    MaxCount = 8
                } });

            // Act:
            InventoryUseCases.TryAddItem(mainInventory, item.Clone());
            InventoryUseCases.TryAddItem(mainInventory, item.Clone());

            // Assert:
            ItemUseCases.TryGetComponent(mainInventory.QuickAccessSlots[0].Item, out StackableItemComponent stackableItemComponent);
            var count = stackableItemComponent.Count;
            Assert.AreEqual(count, 2);
        }
    }
}