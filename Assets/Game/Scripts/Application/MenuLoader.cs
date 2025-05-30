using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class MenuLoader
    {
        [Inject]
        private readonly LoadingScreen loadingScreenPrefab;
        
        [Inject]
        private readonly DiContainer container;
        
        //TODO: Сделать через Addressables
        public void LoadMenu()
        {
            var loadingScreen = Object.Instantiate(loadingScreenPrefab);
            container.Inject(loadingScreen);
            loadingScreen.LoadScene("Assets/Game/Scenes/Menu.unity").Forget();
        }
    }
}