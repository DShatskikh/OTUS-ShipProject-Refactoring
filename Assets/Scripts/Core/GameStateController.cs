using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public enum GameState : byte
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3,
    }
    
    public sealed class GameStateController : MonoBehaviour
    {
        private GameState _gameState;
        private List<IGameListener> _listeners = new ();
        private List<IGameUpdateListener> _updateListeners = new ();
        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new ();
        
        public GameState GetState => _gameState;

        private void Update()
        {
            if (_gameState != GameState.PLAYING)
                return;

            for (int i = 0; i < _updateListeners.Count; i++)
            {
                if (_updateListeners[i] is IGameUpdateListener updateListener)
                    updateListener.OnUpdate();
            }
        }
        
        private void FixedUpdate()
        {
            if (_gameState != GameState.PLAYING)
                return;

            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                if (_fixedUpdateListeners[i] is IGameFixedUpdateListener updateListener)
                    updateListener.OnFixedUpdate();
            }
        }
        
        public void AddListener(IGameListener listener) 
        {
            if (listener == null)
                return;
            
            if (listener is IGameUpdateListener updateListener) 
                _updateListeners.Add(updateListener);

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
                _fixedUpdateListeners.Add(fixedUpdateListener);
            
            _listeners.Add(listener);
        }

        public void StartGame() 
        {
            if (_gameState != GameState.OFF && _gameState != GameState.FINISHED)
                return;
            
            foreach (var listener in _listeners) 
            {
                if (listener is IGameStartListener startListeners) 
                    startListeners.OnStartGame();
            }
            
            _gameState = GameState.PLAYING;
        }

        public void PauseGame()
        {
            if (_gameState != GameState.PLAYING)
                return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IGamePauseListener pauseListeners) 
                    pauseListeners.OnPauseGame();
            }

            _gameState = GameState.PAUSED;
        }

        public void ResumeGame()
        {
            if (_gameState != GameState.PAUSED)
                return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IGameResumeListener resumeListeners) 
                    resumeListeners.OnResumeGame();
            }
            
            _gameState = GameState.PLAYING;
        }
        
        public void FinishGame()
        {
            if (_gameState != GameState.PAUSED && _gameState != GameState.PLAYING)
                return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IGameFinishListener finishListeners) 
                    finishListeners.OnFinishGame();
            }

            _gameState = GameState.FINISHED;
            Debug.Log("Game over!");
        }
    }
}