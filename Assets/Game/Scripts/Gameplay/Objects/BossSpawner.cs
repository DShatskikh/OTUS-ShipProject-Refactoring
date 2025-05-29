using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class BossSpawner : MonoBehaviour
    {
        [SerializeField]
        private string _prefabAddress;
        
        [SerializeField]
        private Transform _spawnPoint;
        
        private AddressablesManager _addressablesManager;

        [Inject]
        private void Construct(AddressablesManager addressablesManager)
        {
            _addressablesManager = addressablesManager;
        }

        private GameObject _spawnedObject;

        private async void Start()
        {
            _spawnedObject = await _addressablesManager.InstantiateAsync(
                _prefabAddress, 
                _spawnPoint);

            if (_spawnedObject != null)
            {
                Debug.Log("Загрузили и заспавнили босса");
            }
        }

        private async void OnDestroy()
        {
            if (_spawnedObject != null)
            {
                Destroy(_spawnedObject);
                await Task.Yield();
                _addressablesManager.ReleaseAsset(_prefabAddress);
                
                Debug.Log("Выгрузили босса из памяти");
            }
        }
    }
}