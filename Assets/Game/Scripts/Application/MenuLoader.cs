using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class MenuLoader
    {
        [Inject]
        private readonly LoadingScreen loadingScreenPrefab;
        
        //TODO: Сделать через Addressables
        public void LoadMenu()
        {
            var loadingScreen = Object.Instantiate(loadingScreenPrefab);
            loadingScreen.LoadScene("Assets/Game/Scenes/Menu.unity").Forget();
        }
    }
}