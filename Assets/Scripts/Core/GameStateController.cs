using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public enum GameState : byte
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3,
    }
    
    public sealed class GameStateController : ITickable, IFixedTickable
    {
        private GameState _gameState;
        private List<IGameListener> _listeners = new ();
        private List<IGameUpdateListener> _updateListeners = new ();
        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new ();
        
        public GameState GetState => _gameState;

        [Inject]
        private void Construct(IEnumerable<IGameListener> listeners)
        {
            _listeners = new List<IGameListener>();
            _updateListeners = new List<IGameUpdateListener>();
            _fixedUpdateListeners = new List<IGameFixedUpdateListener>();
            
            foreach (var listener in listeners)
            {
                AddListener(listener);
            }
        }
        
        public void Tick()
        {
            if (_gameState != GameState.PLAYING)
                return;

            for (int i = 0; i < _updateListeners.Count; i++) 
                _updateListeners[i].OnUpdate();
        }

        public void FixedTick()
        {
            if (_gameState != GameState.PLAYING)
                return;

            for (int i = 0; i < _fixedUpdateListeners.Count; i++) 
                _fixedUpdateListeners[i].OnFixedUpdate();
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