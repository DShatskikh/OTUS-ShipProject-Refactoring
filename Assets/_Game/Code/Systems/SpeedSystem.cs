using System;

namespace Game.Systems
{
    [Serializable]
    public class SpeedSystem
    {
        public int Speed;
        public event Action<int> OnChange;
        
        public void AddSpeed(int value)
        {
            Speed += value;
            OnChange?.Invoke(Speed);
        }
        
        public void RemoveSpeed(int value)
        {
            Speed -= value;
            OnChange?.Invoke(Speed);
        }
    }
}