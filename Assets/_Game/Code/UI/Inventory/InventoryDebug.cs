using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class InventoryDebug : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemConfig[] _initConfigs;
        
        private Inventory.Inventory _inventory;
        private DiContainer _container;

        [Inject]
        private void Construct(Inventory.Inventory inventory, DiContainer container)
        {
            _inventory = inventory;
            _container = container;
        }

        private void Start()
        {
            foreach (var config in _initConfigs) 
                AddItem(config);
        }

        [Button]
        private void AddItem(InventoryItemConfig config)
        {
            var item = config.Prototype.Clone();

            foreach (var component in item.Components) 
                _container.Inject(component);

            _inventory.Add(item);
        }
    }
}