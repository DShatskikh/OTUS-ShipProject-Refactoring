using UnityEngine;

namespace Game.Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Configs/Item", order = 200)]
    public class InventoryItemConfig : ScriptableObject
    {
        public InventoryItem Prototype;
    }
}