using Game.Inventory;
using Game.Systems;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ItemObserverTests
    {
        // Получаем предмет увеличивающий скорость
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
            armorInventory.HelmetSlot.NotifyChange(item1, null);

            // Assert:
            Assert.AreEqual(speedSystem.Speed, 1);
        }

        // Получаем и выкидываем предмет увеличивающий скорость
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
            armorInventory.HelmetSlot.NotifyChange(item1, null);
            
            armorInventory.HelmetSlot.Item = null;
            armorInventory.HelmetSlot.NotifyChange(null, item1);

            // Assert:
            Assert.AreEqual(speedSystem.Speed, 0);
        }
        
        // Получаем предмет увеличивающий здоровье
        [Test]
        public void WhenItemHealthComponentObserver_ThenHealth1()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var healthSystem = new HealthSystem();
            var observer = new ItemHealthComponentObserver(armorInventory, healthSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 4 },
                    new HealthComponent() { Health = 1 }
                });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.HelmetSlot.NotifyChange(item1, null);

            // Assert:
            Assert.AreEqual(healthSystem.Health, 1);
        }

        // Получаем и выкидываем предмет увеличивающий здоровье
        [Test]
        public void WhenItemHealthComponentObserver_ThenHealth0()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var healthSystem = new HealthSystem();
            var observer = new ItemHealthComponentObserver(armorInventory, healthSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 4 },
                    new HealthComponent() { Health = 1 }
                });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.HelmetSlot.NotifyChange(item1, null);

            armorInventory.HelmetSlot.Item = null;
            armorInventory.HelmetSlot.NotifyChange(null, item1);
            
            // Assert:
            Assert.AreEqual(healthSystem.Health, 0);
        }
        
        // Получаем предмет увеличивающий броню
        [Test]
        public void WhenItemArmorComponentObserver_ThenArmor1()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var armorSystem = new ArmorSystem();
            var observer = new ItemArmorComponentObserver(armorInventory, armorSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.HelmetSlot.NotifyChange(item1, null);

            // Assert:
            Assert.AreEqual(armorSystem.Armor, 1);
        }

        // Получаем и выкидываем предмет увеличивающий броню
        [Test]
        public void WhenItemArmorComponentObserver_ThenArmor0()
        {
            // Arrange:
            var armorInventory = new ArmorInventory();
            var armorSystem = new ArmorSystem();
            var observer = new ItemArmorComponentObserver(armorInventory, armorSystem);
            
            var item1 = new InventoryItem("Helmet", new InventoryItemMetaData("Тестовый шлем", "Добавь описание...", null), 
                ItemFlags.EQUIPPABLE, new IItemComponent[]
                {
                    new ArmorComponent() { Armor = 1 },
                });

            // Act:
            armorInventory.HelmetSlot.Item = item1;
            armorInventory.HelmetSlot.NotifyChange(item1, null);

            armorInventory.HelmetSlot.Item = null;
            armorInventory.HelmetSlot.NotifyChange(null, item1);
            
            // Assert:
            Assert.AreEqual(armorSystem.Armor, 0);
        }
    }
}