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
        
        private MainInventory _mainInventory;
        private DiContainer _container;

        [Inject]
        private void Construct(MainInventory mainInventory, DiContainer container)
        {
            _mainInventory = mainInventory;
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

            _mainInventory.Add(item);
        }
    }
}