using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseScreen : MonoBehaviour
    {
        [SerializeField]
        private Button resumeButton;

        [SerializeField]
        private Button exitButton;

        private MenuLoader menuLoader;
        private GameLoader gameLoader;

        [Inject]
        public void Construct(MenuLoader menuLoader, GameLoader gameLoader)
        {
            this.menuLoader = menuLoader;
            this.gameLoader = gameLoader;
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.resumeButton.onClick.AddListener(this.Hide);
            this.exitButton.onClick.AddListener(this.menuLoader.LoadMenu);
            this.exitButton.onClick.AddListener(this.gameLoader.UnloadGame);
        }

        private void OnDisable()
        {
            this.resumeButton.onClick.RemoveListener(this.Hide);
            this.exitButton.onClick.RemoveListener(this.menuLoader.LoadMenu);
            this.exitButton.onClick.RemoveListener(this.gameLoader.UnloadGame);
        }

        public void Show()
        {
            Time.timeScale = 0; //KISS
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            Time.timeScale = 1; //KISS
            this.gameObject.SetActive(false);
        }
    }
}