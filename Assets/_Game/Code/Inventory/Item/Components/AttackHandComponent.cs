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
        private HandInventory _handInventory;

        [Inject]
        public void Construct(AttackSystem attackSystem, HandInventory handInventory)
        {
            _attackSystem = attackSystem;
            _handInventory = handInventory;
            
            _handInventory.OnItemAdded += OnItemAdded;
            _handInventory.OnItemRemoved += OnItemRemoved;
        }

        private void OnItemAdded(InventoryItem item) => 
            _attackSystem.AddAttack(Attack);

        private void OnItemRemoved(InventoryItem item) => 
            _attackSystem.RemoveAttack(Attack);

        public IItemComponent Clone() => 
            new AttackHandComponent() { Attack = Attack };
    }
}