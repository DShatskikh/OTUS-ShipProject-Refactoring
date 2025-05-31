using Cysharp.Threading.Tasks;
using UnityEngine;
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

        [Inject]
        private IAssetLoader assetLoader;
        
        private SceneInstance sceneHandle;

        //TODO: Сделать через Addressables
        public void UnloadGame()
        {
            if (sceneHandle.Scene.IsValid())
            {
                assetLoader.ReleaseAsset("Assets/Game/Scenes/Menu.unity");
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