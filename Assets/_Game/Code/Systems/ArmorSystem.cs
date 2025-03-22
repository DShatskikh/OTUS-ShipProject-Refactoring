using System;

namespace Game.Systems
{
    public sealed class ArmorSystem
    {
        public int Armor;
        public event Action<int> OnChange;
        
        public void AddArmor(int value)
        {
            Armor += value;
            OnChange?.Invoke(Armor);
        }
        
        public void RemoveArmor(int value)
        {
            Armor -= value;
            OnChange?.Invoke(Armor);
        }
    }
}