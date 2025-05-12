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
            
            // Загружаем сцену
            var operation = Addressables.LoadSceneAsync(sceneKey, LoadSceneMode.Single, false);

            while (!operation.IsDone)
            {
                // Обновляем прогресс загрузки
                if (progressBar != null)
                    progressBar.value = operation.PercentComplete;

                label.text = $"Loading {operation.PercentComplete}%";
                await UniTask.DelayFrame(1);
            }

            Destroy(gameObject);
            
            // Проверяем на ошибки
            if (operation.Status == AsyncOperationStatus.Succeeded)
            {
                // Когда загрузка завершена, активируем сцену
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