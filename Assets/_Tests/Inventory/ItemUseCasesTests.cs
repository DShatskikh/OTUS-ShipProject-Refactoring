using Game.Inventory;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ItemUseCasesTests
    {
        // CanFlag STACKABLE
        [Test]
        public void WhenCanFlagSTACKABLE_ThenTrue()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.STACKABLE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            // Act:
            var result = ItemUseCases.CanFlag(item, ItemFlags.STACKABLE);

            // Assert:
            Assert.IsTrue(result);
        }
        
        // CanFlag EQUIPPABLE
        [Test]
        public void WhenCanFlagEQUIPPABLE_ThenTrue()
        {
            // Arrange:
            var item = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });

            // Act:
            var result = ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE);

            // Assert:
            Assert.IsTrue(result);
        }
        
        // CanFlag STACKABLE and EQUIPPABLE
        [Test]
        public void WhenCanFlagSTACKABLEAndEQUIPPABLE_ThenTrue()
        {
            // Arrange:
            var item = new InventoryItem("BreadHelmet", new InventoryItemMetaData("Шлем из хлеба", "Добавь описание...", null), 
                 ItemFlags.EQUIPPABLE + (int)ItemFlags.STACKABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });

            // Act:
            var result = ItemUseCases.CanFlag(item, ItemFlags.EQUIPPABLE) 
                         && ItemUseCases.CanFlag(item, ItemFlags.STACKABLE);

            // Assert:
            Assert.IsTrue(result);
        }
        
        // CanFlag Not STACKABLE
        [Test]
        public void WhenCanFlagSTACKABLE_ThenFalse()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            // Act:
            var result = ItemUseCases.CanFlag(item, ItemFlags.STACKABLE);

            // Assert:
            Assert.IsFalse(result);
        }
        
        // TryGetComponent есть компонент
        [Test]
        public void WhenTryGetComponentStackable_ThenNotNull()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { new StackableItemComponent() { Count = 1, MaxCount = 8 } });

            // Act:
            var result = ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent);

            // Assert:
            Assert.NotNull(stackableItemComponent);
        }
        
        // TryGetComponent нет компонента
        [Test]
        public void WhenTryGetComponentStackable_ThenNull()
        {
            // Arrange:
            var item = new InventoryItem("Bread", new InventoryItemMetaData("Хлеб", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { });

            // Act:
            var result = ItemUseCases.TryGetComponent(item, out StackableItemComponent stackableItemComponent);

            // Assert:
            Assert.Null(stackableItemComponent);
        }
    }
}