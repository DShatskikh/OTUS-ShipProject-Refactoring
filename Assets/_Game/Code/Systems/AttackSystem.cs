using System;

namespace Game.Systems
{
    [Serializable]
    public sealed class AttackSystem
    {
        public int Attack;
        public event Action<int> OnChange;
        
        public void AddAttack(int value)
        {
            Attack += value;
            OnChange?.Invoke(Attack);
        }
        
        public void RemoveAttack(int value)
        {
            Attack -= value;
            OnChange?.Invoke(Attack);
        }
    }
}