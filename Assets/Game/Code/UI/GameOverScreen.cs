using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOver;
        
        private void Start()
        {
            var player = SceneContext.Instance.GetPlayer();
            player.GetHitPoints().Subscribe(points =>
            {
                if (points <= 0)
                {
                    _gameOver.SetActive(true);
                    Time.timeScale = 0;
                }
            });
        }
    }
}