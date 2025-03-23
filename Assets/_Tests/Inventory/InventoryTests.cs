using Game.Inventory;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public sealed class InventoryTests
    {
        [Test]
        public void WhenAddStackable_Then6()
        {
            // Arrange:
            var inventory = new Inventory();
            var item1 = new InventoryItem("Stone", new InventoryItemMetaData("Камень", "Обычный камень", null), ItemFlags.STACKABLE, new IItemComponent[]
            {
                new StackableItemComponent() { Count = 4, MaxCount = 6 }
            });

            var item2 = item1.Clone();
            
            // Act:
            inventory.Add(item1);
            inventory.Add(item2);
            
            ItemUseCases.TryGetComponent(inventory.Items[0, 0], out StackableItemComponent stackableItemComponent);
            
            // Assert:
            Assert.AreEqual(stackableItemComponent.Count, 6);
        }
        
        [Test]
        public void WhenAdd_ThenItem()
        {
            // Arrange:
            var inventory = new Inventory();
            var item1 = new InventoryItem("Stone", new InventoryItemMetaData("Камень", "Обычный камень", null), ItemFlags.STACKABLE, new IItemComponent[]
            {
                new StackableItemComponent() { Count = 1, MaxCount = 5 }
            });
            
            // Act:
            inventory.Add(item1);
            
            // Assert:
            Assert.NotNull(inventory.Items[0, 0]);
        }
    }
}