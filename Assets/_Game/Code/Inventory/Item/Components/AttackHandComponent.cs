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