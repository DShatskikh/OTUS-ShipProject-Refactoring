using Game.Inventory;
using Game.Systems;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public sealed class ArmorInventoryTests
    {
        [Test]
        public void WhenArmorAddArmor_ThenArmor5()
        {
            // Увеличилась броня при надевании брони
            
            // Arrange:
            var armorInventory = new ArmorInventory();
            var armorSystem = new ArmorSystem();
            var armorComponent = new ArmorComponent() { Armor = 5 };

            var helmetItem = new InventoryItem("Helmet", 
                new InventoryItemMetaData("Шлем", "Обычный шлем", null), 
                ItemFlags.NONE, 
                new IItemComponent[]{ armorComponent });

            ItemUseCases.TryGetComponent(helmetItem, out ArmorComponent cloneArmorComponent);
            cloneArmorComponent.Construct(armorInventory, armorSystem);
            
            // Act:
            InventoryUseCases.AddItem(armorInventory, helmetItem);
            
            // Assert:
            Assert.AreEqual(armorSystem.Armor, 5);
        }
        
        [Test]
        public void WhenArmorAddSpeed_ThenSpeed5()
        {
            // Увеличилась скорость при надевании брони
            
            // Arrange:
            var armorInventory = new ArmorInventory();
            var speedSystem = new SpeedSystem();
            var speedArmorComponent = new SpeedArmorComponent() { Speed = 5 };

            var helmetItem = new InventoryItem("Helmet", 
                new InventoryItemMetaData("Шлем", "Обычный шлем", null), 
                ItemFlags.NONE, 
                new IItemComponent[]{ speedArmorComponent });

            ItemUseCases.TryGetComponent(helmetItem, out SpeedArmorComponent cloneArmorComponent);
            cloneArmorComponent.Construct(armorInventory, speedSystem);
            
            // Act:
            InventoryUseCases.AddItem(armorInventory, helmetItem);
            
            // Assert:
            Assert.AreEqual(speedSystem.Speed, 5);
        }
    }
}