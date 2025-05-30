using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Zenject;

namespace SampleGame
{
    public sealed class GameLoader
    {
        [Inject]
        private readonly LoadingScreen loadingScreenPrefab;
        
        [Inject]
        private readonly DiContainer container;
        
        private SceneInstance sceneHandle;

        //TODO: Сделать через Addressables
        public void UnloadGame()
        {
            if (sceneHandle.Scene.IsValid())
            {
                Addressables.UnloadSceneAsync(sceneHandle).Completed += op =>
                {
                    if (op.Status == AsyncOperationStatus.Succeeded)
                        Debug.Log("Scene unloaded successfully");
                };
            }
        }
        
        //TODO: Сделать через Addressables
        public void LoadGame()
        {
            AsyncLoadGame().Forget();
        }

        private async UniTask AsyncLoadGame()
        {
            var loadingScreen = Object.Instantiate(loadingScreenPrefab);
            container.Inject(loadingScreen);
            sceneHandle = await loadingScreen.LoadScene("Assets/Game/Scenes/Game.unity");
        }
    }
}