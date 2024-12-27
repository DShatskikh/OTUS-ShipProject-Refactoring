using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PauseGameScreen : ScreenBase, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        [SerializeField]
        private GameStateController _gameStateController;

        [SerializeField]
        private Button _resumeButton;

        public void OnPauseGame()
        {
            Show();
        }

        public void OnResumeGame()
        {
            Hide();
        }

        public void OnFinishGame()
        {
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

        private void Resume()
        {
            _gameStateController.ResumeGame();
        }
    }
}