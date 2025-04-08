using System;
using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public class AttackHandComponent : IItemComponent
    {
        public int Attack;
        
        private AttackSystem _attackSystem;
        private ArmorInventory _armorInventory;

        [Inject]
        public void Construct(AttackSystem attackSystem, ArmorInventory armorInventory)
        {
            _attackSystem = attackSystem;
            _armorInventory = armorInventory;
            
            _armorInventory.HandSlot.OnItemAdded += OnItemAdded;
            _armorInventory.HandSlot.OnItemRemoved += OnItemRemoved;
        }

        public IItemComponent Clone() => 
            new AttackHandComponent() { Attack = Attack };

        private void OnItemAdded(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _attackSystem.AddAttack(Attack);
        }

        private void OnItemRemoved(InventoryItem item)
        {
            if (!ItemUseCases.CanComponent(item, this))
                return;
            
            _attackSystem.RemoveAttack(Attack);
        }
    }
}