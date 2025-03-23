using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game.Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Configs/Item", order = 200)]
    public class InventoryItemConfig : ScriptableObject
    {
        public InventoryItem Prototype;

        [Tooltip("В инспекторе есть баг что при переименовании компонента пропадает возможность менять конфиг")]
        [Button]
        private void CreateCopyAsset()
        {
            var created = CreateInstance<InventoryItemConfig>();
            created.Prototype = Prototype.Clone();
            AssetDatabase.CreateAsset(created, $"Assets/_Game/Configs/{created.Prototype.Id}.asset");
        }
    }
}