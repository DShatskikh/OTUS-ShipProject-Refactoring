using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
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
        
        private IAssetLoader _assetLoader;

        [Inject]
        private void Construct(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        private GameObject _spawnedObject;

        private void Start()
        {
            CreateBoss().Forget();
        }

        private void OnDestroy()
        {
            if (_spawnedObject != null)
            {
                RemoveBoss().Forget();
            }
        }

        private async UniTask CreateBoss()
        {
            _spawnedObject = await _assetLoader.InstantiateAsync(
                _prefabAddress, 
                _spawnPoint);

            if (_spawnedObject != null)
            {
                Debug.Log("Загрузили и заспавнили босса");
            }
        }

        private async UniTask RemoveBoss()
        {
            Destroy(_spawnedObject);
            await Task.Yield();
            _assetLoader.ReleaseAsset(_prefabAddress);
                
            Debug.Log("Выгрузили босса из памяти");
        }
    }
}