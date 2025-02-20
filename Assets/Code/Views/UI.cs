using System.Collections;
using Leopotam.EcsLite.Entities;
using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class UI : MonoBehaviour
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
        
        private IEnumerator Start()
        {
            yield return null;
            _gameStateController = EcsStartup.Instance.GameStateController;
            yield return new WaitUntil(() => !_gameStateController.GetIsPlaying);
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