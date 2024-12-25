using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField]
        private GameStateController _gameStateController;
        
        [SerializeField]
        private Transform[] _roots;

        [SerializeField]
        private StartGameScreen _startGameScreen;
        
        private void Awake()
        {
            foreach (var root in _roots)
            {
                foreach (var gameListener in root.GetComponentsInChildren<IGameListener>(true))
                {
                    _gameStateController.AddListener(gameListener);
                }
            }
        }

        private void Start()
        {
            _startGameScreen.Show();
        }
    }
}