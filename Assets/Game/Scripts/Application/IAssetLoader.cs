using System.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    public interface IAssetLoader
    {
        public Task<GameObject> InstantiateAsync(
            string address,
            Transform parent = null,
            bool worldPositionStays = false);

        public Task<GameObject> LoadAssetAsync(string address);
        public void ReleaseAsset(string address);
        public void ReleaseAll();
    }
}