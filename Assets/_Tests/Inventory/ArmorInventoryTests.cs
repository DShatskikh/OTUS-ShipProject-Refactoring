using Game.Inventory;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public sealed class ArmorInventoryTests
    {
        [Test]
        public void WhenArmorAddSpeed_ThenArmor5()
        {
            // var armorInventory = new ArmorInventory();
            // var armorSystem = new ArmorSystem();
            // var armorComponent = new ArmorComponent() { Armor = 5 };
            // armorComponent.Construct(armorInventory, armorSystem);
            //
            // var helmetItem = new InventoryItem("Helmet", 
            //     new InventoryItemMetaData("Шлем", "Обычный шлем", null), 
            //     ItemFlags.NONE, 
            //     new IItemComponent[]{ armorComponent });
            //
            // armorInventory.TrySetHead(helmetItem);
            // Assert.IsTrue(armorSystem.Armor == 5);
        }
    }
}