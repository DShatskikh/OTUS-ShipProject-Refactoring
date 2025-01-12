using System.Collections.Generic;
using UnityEngine;

namespace GameCycle
{
    public sealed class GameStateController
    {
        private GameState _gameState;
        private List<IGameListener> _listeners = new ();
        
        public GameState GetState => _gameState;

        public void AddListener(IGameListener listener) 
        {
            if (listener == null)
                return;

            _listeners.Add(listener);
        }

        public void RemoveListener(IGameListener listener) 
        {
            _listeners.Remove(listener);
        }

        public void StartGame() 
        {
            if (_gameState != GameState.OFF && _gameState != GameState.FINISHED)
                return;

            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameStartListener startListeners) 
                    startListeners.OnStartGame();
            }

            _gameState = GameState.PLAYING;
        }

        public void PauseGame()
        {
            if (_gameState != GameState.PLAYING)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGamePauseListener pauseListeners) 
                    pauseListeners.OnPauseGame();
            }

            _gameState = GameState.PAUSED;
        }

        public void ResumeGame()
        {
            if (_gameState != GameState.PAUSED)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameResumeListener resumeListeners) 
                    resumeListeners.OnResumeGame();
            }
            
            _gameState = GameState.PLAYING;
        }

        public void FinishGame()
        {
            if (_gameState != GameState.PAUSED && _gameState != GameState.PLAYING)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameFinishListener finishListeners) 
                    finishListeners.OnFinishGame();
            }

            _gameState = GameState.FINISHED;
            Debug.Log("Game over!");
        }
    }
}