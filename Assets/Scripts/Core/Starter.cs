using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _roots;

        [SerializeField]
        private StartGameScreen _startGameScreen;

        private GameStateController _gameStateController;
        private DiContainer _diContainer;

        [Inject]
        private void Construct(GameStateController gameStateController, DiContainer diContainer)
        {
            _gameStateController = gameStateController;
            _diContainer = diContainer;
        }
        
        private void Awake()
        {
            _diContainer.Inject(_gameStateController);
            
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