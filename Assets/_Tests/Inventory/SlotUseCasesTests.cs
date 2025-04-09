using Game.Inventory;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SlotUseCasesTests
    {
        // Удаляем предмет их слота
        [Test]
        public void WhenRemoveItem_ThenNull()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            var slot = new Slot
            {
                Item = item.Clone()
            };

            // Act:
            SlotUseCases.RemoveItem(slot);

            // Assert:
            Assert.Null(slot.Item);
        }
        
        // TryRemoveOneItem когда у нас 1 не стакаемый предмет
        [Test]
        public void WhenTryRemoveOneItemNotStackable_ThenNull()
        {
            // Arrange:
            var item = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });

            var slot = new Slot
            {
                Item = item.Clone()
            };

            // Act:
            SlotUseCases.TryRemoveOneItem(slot);

            // Assert:
            Assert.Null(slot.Item);
        }
        
        // TryRemoveOneItem когда у нас 1 стакаемый предмет
        [Test]
        public void WhenTryRemoveOneItemStackable_ThenNull()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            var slot = new Slot
            {
                Item = item.Clone()
            };

            // Act:
            SlotUseCases.TryRemoveOneItem(slot);

            // Assert:
            Assert.Null(slot.Item);
        }
        
        // TryRemoveOneItem когда у нас 2 стакаемых предмета
        [Test]
        public void WhenTryRemoveOneItem2Stackable_ThenNull()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 2, MaxCount = 8 } });

            var slot = new Slot
            {
                Item = item.Clone()
            };

            // Act:
            SlotUseCases.TryRemoveOneItem(slot);

            // Assert:
            ItemUseCases.TryGetComponent(slot.Item, out StackableItemComponent stackableItemComponent);
            Assert.AreEqual(stackableItemComponent.Count, 1);
        }
        
        // TrySwitch разные предметы
        [Test]
        public void WhenTrySwitchDifferent_ThenTrue()
        {
            // Arrange:
            var item1 = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 2, MaxCount = 8 } });

            var item2 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });
            
            var slot1 = new Slot
            {
                Item = item1.Clone()
            };

            var slot2 = new Slot
            {
                Item = item2.Clone()
            };
            
            // Act:
            var result = SlotUseCases.TrySwitch(slot1, slot2);

            // Assert:
            Assert.True(result);
        }
        
        // TrySwitch стакаемые предметы 1 и 1
        [Test]
        public void WhenTrySwitchStackable_Then2()
        {
            // Arrange:
            var item1 = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            var slot1 = new Slot
            {
                Item = item1.Clone()
            };

            var slot2 = new Slot
            {
                Item = item1.Clone()
            };
            
            // Act:
            SlotUseCases.TrySwitch(slot1, slot2);
            ItemUseCases.TryGetComponent(slot1.Item, out StackableItemComponent stackableItemComponent);
            var result = stackableItemComponent.Count;

            // Assert:
            Assert.AreEqual(result, 2);
        }
        
        // TryAdd стакаемые предметы
        [Test]
        public void WhenTryAddStackable_Then2()
        {
            // Arrange:
            var item1 = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            var slot1 = new Slot
            {
                Item = item1.Clone()
            };
            
            // Act:
            SlotUseCases.TryAdd(slot1, item1.Clone(), out int remains);
            ItemUseCases.TryGetComponent(slot1.Item, out StackableItemComponent stackableItemComponent);
            var result = stackableItemComponent.Count;

            // Assert:
            Assert.AreEqual(result, 2);
        }
    }
}