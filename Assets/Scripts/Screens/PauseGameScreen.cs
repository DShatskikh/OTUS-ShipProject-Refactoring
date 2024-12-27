using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PauseGameScreen : ScreenBase, IGamePauseListener, IGameResumeListener, IGameStartListener, IGameFinishListener
    {
        [SerializeField]
        private GameStateController _gameStateController;

        [SerializeField]
        private Button _resumeButton;

        [SerializeField]
        private InputManager _inputManager;
        
        public void OnStartGame()
        {
            _inputManager.Pause += Pause;
        }

        public void OnPauseGame()
        {
            Show();
            _inputManager.Pause += Resume;
        }

        public void OnResumeGame()
        {
            Hide();
            _inputManager.Pause += Pause;
        }

        public void OnFinishGame()
        {
            _inputManager.Pause -= Pause;
            Hide();
        }

        public override void Show()
        {
            base.Show();
            _resumeButton.onClick.AddListener(Resume);
        }

        public override void Hide()
        {
            base.Hide();
            _resumeButton.onClick.RemoveAllListeners();
        }

        private void Pause()
        {
            _gameStateController.PauseGame();
            _inputManager.Pause -= Pause;
        }

        private void Resume()
        {
            _gameStateController.ResumeGame();
            _inputManager.Pause -= Resume;
        }
    }
}