using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SampleGame
{
    public sealed class AddressablesManager
    {
        private Dictionary<string, AsyncOperationHandle<GameObject>> _loadedAssets = new();

        public async Task<GameObject> InstantiateAsync(
            string address,
            Transform parent = null,
            bool worldPositionStays = false)
        {
            if (_loadedAssets.TryGetValue(address, out var handle))
            {
                if (handle.Result != null)
                {
                    return Object.Instantiate(handle.Result, parent, worldPositionStays);
                }
            }

            var loadHandle = Addressables.LoadAssetAsync<GameObject>(address);
            await loadHandle.Task;

            if (loadHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedAssets[address] = loadHandle;
                return Object.Instantiate(loadHandle.Result, parent, worldPositionStays);
            }

            Debug.LogError($"Failed to load asset at address: {address}");
            return null;
        }

        public async Task<GameObject> LoadAssetAsync(string address)
        {
            if (_loadedAssets.TryGetValue(address, out var handle))
            {
                return handle.Result;
            }

            var loadHandle = Addressables.LoadAssetAsync<GameObject>(address);
            await loadHandle.Task;

            if (loadHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedAssets[address] = loadHandle;
                return loadHandle.Result;
            }

            Debug.LogError($"Failed to load asset at address: {address}");
            return null;
        }

        public void ReleaseAsset(string address)
        {
            if (_loadedAssets.TryGetValue(address, out var handle))
            {
                Addressables.Release(handle);
                _loadedAssets.Remove(address);
            }
        }

        public void ReleaseAll()
        {
            foreach (var handle in _loadedAssets.Values)
            {
                Addressables.Release(handle);
            }

            _loadedAssets.Clear();
        }
    }
}