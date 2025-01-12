using GameCycle;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public class MainGameScreen : ScreenBase, IGameStartListener, IGameFinishListener, IGameResumeListener, IGamePauseListener
    {
        [SerializeField]
        private Button _pauseButton;

        private GameStateController _gameStateController;
        
        [Inject]
        private void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
        
        public void OnStartGame()
        {
            Show();
        }

        public void OnFinishGame()
        {
            Hide();
        }

        public void OnResumeGame()
        {
            Show();
        }

        public void OnPauseGame()
        {
            Hide();
        }

        private void OnClickPauseButton()
        {
            _gameStateController.PauseGame();
        }

        public override void Show()
        {
            base.Show();
            _pauseButton.onClick.AddListener(OnClickPauseButton);
        }
        
        public override void Hide()
        {
            base.Hide();
            _pauseButton.onClick.RemoveAllListeners();
        }
    }
}