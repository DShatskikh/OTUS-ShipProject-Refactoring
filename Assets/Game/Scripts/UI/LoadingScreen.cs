using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class LoadingScreen : MonoBehaviour
    {
        [SerializeField]
        private Slider progressBar;

        [SerializeField]
        private TMP_Text label;
        
        public async UniTask<SceneInstance> LoadScene(string sceneKey)
        {
            gameObject.SetActive(true);
            var operation = Addressables.LoadSceneAsync(sceneKey, LoadSceneMode.Single, false);

            while (!operation.IsDone)
            {
                if (progressBar != null)
                    progressBar.value = operation.PercentComplete;

                label.text = $"Loading {operation.PercentComplete}%";
                await UniTask.DelayFrame(1);
            }

            Destroy(gameObject);

            if (operation.Status == AsyncOperationStatus.Succeeded)
            {
                operation.Result.ActivateAsync();
                return operation.Result;
            }
            else
            {
                throw new Exception($"Failed to load scene: {sceneKey}");
            }
        }
    }
}