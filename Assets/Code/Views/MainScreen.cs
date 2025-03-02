using System.Collections;
using Cysharp.Threading.Tasks;
using Leopotam.EcsLite.Entities;
using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class MainScreen : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _orcHealthLabel;

        [SerializeField]
        private Entity _orcBaseEntity;
        
        [SerializeField]
        private TMP_Text _humanHealthLabel;
        
        [SerializeField]
        private Entity _humanBaseEntity;

        [SerializeField]
        private GameObject _gameEndScreen;

        private GameStateController _gameStateController;
        
        private async void Start()
        {
            await UniTask.Yield();
            _gameStateController = EcsStartup.Instance.GameStateController;
            await UniTask.WaitUntil(() => !_gameStateController.GetIsPlaying);
            _gameEndScreen.SetActive(true);
        }

        private void Update()
        {
            _orcBaseEntity.TryGetData<Health>(out var orcHealth);
            _orcHealthLabel.text = $"Orcs: {orcHealth.Current}/{orcHealth.Max}";
            
            _humanBaseEntity.TryGetData<Health>(out var humanHealth);
            _humanHealthLabel.text = $"Humans: {humanHealth.Current}/{humanHealth.Max}";
        }
    }
}