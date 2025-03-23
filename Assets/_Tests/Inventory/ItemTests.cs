using Game.Inventory;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public sealed class ItemTests
    {
        [Test]
        public void WhenCloneMetaData_ThenEqual()
        {
            // Arrange:
            var name = "Меч";
            var description = "Обычный меч";
            var icon = Resources.Load<Sprite>("PortraitMon");
            var metaData = new InventoryItemMetaData(name, description, icon);
            
            // Act:
            var clone = metaData.Clone();
            
            // Assert:
            Assert.IsTrue(name == clone.Name);
            Assert.IsTrue(description == clone.Description);
            Assert.IsTrue(icon == clone.Icon);
        }
        
        [Test]
        public void WhenCloneItem_ThenEqual()
        {
            // Arrange:
            var id = "Sword";
            var flags = ItemFlags.NONE;
            var name = "Меч";
            var description = "Обычный меч";
            var icon = Resources.Load<Sprite>("PortraitMon");
            var metaData = new InventoryItemMetaData(name, description, icon);
            var components = new IItemComponent[] {};
            var item = new InventoryItem(id, metaData, flags, components);
            
            // Act:
            var clone = item.Clone();
            
            // Assert:
            Assert.IsTrue(item.Id == clone.Id);
            Assert.IsTrue(item.Flags == clone.Flags);
            Assert.IsTrue(item.Components.Length == clone.Components.Length);
            Assert.IsTrue(name == clone.MetaData.Name);
            Assert.IsTrue(description == clone.MetaData.Description);
            Assert.IsTrue(icon == clone.MetaData.Icon);
        }
    }
}