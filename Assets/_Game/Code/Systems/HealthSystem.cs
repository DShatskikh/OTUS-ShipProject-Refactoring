using System;

namespace Game.Systems
{
    [Serializable]
    public class HealthSystem
    {
        public int Health;
        public event Action<int> OnChange;
        
        public void AddHealth(int value)
        {
            Health += value;
            OnChange?.Invoke(Health);
        }
        
        public void RemoveHealth(int value)
        {
            Health -= value;
            OnChange?.Invoke(Health);
        }
    }
}