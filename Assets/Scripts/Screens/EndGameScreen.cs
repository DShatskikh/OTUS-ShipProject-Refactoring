using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class EndGameScreen : ScreenBase, IGameFinishListener
    {
        [SerializeField]
        private Button _restartButton;

        public void OnFinishGame()
        {
            Show();
        }

        public override void Show()
        {
            base.Show();
            _restartButton.onClick.AddListener(RestartGame);
            Time.timeScale = 0;
        }

        public override void Hide()
        {
            base.Hide();
            _restartButton.onClick.RemoveAllListeners();
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}