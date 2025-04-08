using Game.Inventory;
using Game.Systems;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ItemObserverTests
    {
        [Test]
        public void WhenItemSpeedComponentObserver_ThenSpeed1()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var speedSystem = new SpeedSystem();
            var observer = new ItemSpeedComponentObserver(armorInventory, speedSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
            {
                new ArmorComponent() { Armor = 4 },
                new SpeedComponent() { Speed = 1 }
            });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.NotifyChangeSlot(item1, null, null);

            // Assert:
            Assert.AreEqual(speedSystem.Speed, 1);
        }

        [Test]
        public void WhenItemSpeedComponentObserver_ThenSpeed0()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var speedSystem = new SpeedSystem();
            var observer = new ItemSpeedComponentObserver(armorInventory, speedSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 4 },
                    new SpeedComponent() { Speed = 1 }
                });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.NotifyChangeSlot(item1, null, null);
            
            armorInventory.HelmetSlot.Item = null;
            armorInventory.NotifyChangeSlot(null, item1, null);

            // Assert:
            Assert.AreEqual(speedSystem.Speed, 0);
        }
    }
}