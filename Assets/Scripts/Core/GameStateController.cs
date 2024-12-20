using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameStateController : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}