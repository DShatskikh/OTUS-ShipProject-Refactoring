namespace Game
{
    public class GameStateController
    {
        private bool _getIsPlaying = true;
        public bool GetIsPlaying => _getIsPlaying;

        public void EndGame()
        {
            _getIsPlaying = false;
        }
    }
}