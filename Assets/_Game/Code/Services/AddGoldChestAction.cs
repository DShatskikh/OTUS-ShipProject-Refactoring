using UnityEngine;

namespace Game
{
    public class AddGoldChestAction : IOpenChestAction
    {
        public int Gold;
        
        public void Open()
        {
            Debug.Log($"Добавили {Gold} золота");
        }
    }
}