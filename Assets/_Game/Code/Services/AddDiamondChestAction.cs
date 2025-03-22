using UnityEngine;

namespace Game
{
    public class AddDiamondChestAction : IOpenChestAction
    {
        public int Diamond;
        
        public void Open()
        {
            Debug.Log($"Добавили {Diamond} алмазов");
        }
    }
}