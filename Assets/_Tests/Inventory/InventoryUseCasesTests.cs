using Game.Inventory;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InventoryUseCasesTests
    {
        // Добавляем предмет в пустой инвентарь
        [Test]
        public void WhenItemSpeedComponentObserver_ThenSpeed1()
        {
            // Arrange:
            var mainInventory = new MainInventory();
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.NONE, new IItemComponent[] { });

            // Act:
            InventoryUseCases.TryAddItem(mainInventory, item1);

            // Assert:
            var result = mainInventory.MainSlots[0, 0].Item;
            Assert.AreEqual(result.Id, item1.Id);
        }
    }
}