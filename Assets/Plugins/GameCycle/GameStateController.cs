using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameCycle
{
    public sealed class GameStateController : ITickable, IFixedTickable
    {
        private GameState _gameState;
        
        private readonly List<IGameListener> _listeners = new ();
        private readonly List<IGameTickableListener> _tickables = new ();
        private readonly List<IGameFixedUpdateListener> _fixedTickables = new ();
        
        public GameState GetState => _gameState;

        public void AddListener(IGameListener listener) 
        {
            if (listener == null)
                return;

            _listeners.Add(listener);
            
            if (listener is IGameTickableListener tickableListener)
                _tickables.Add(tickableListener);
            
            if (listener is IGameFixedUpdateListener fixedUpdateListener)
                _fixedTickables.Add(fixedUpdateListener);
        }

        public void RemoveListener(IGameListener listener) 
        {
            if (listener is IGameTickableListener tickableListener)
                _tickables.Remove(tickableListener);
            
            if (listener is IGameFixedUpdateListener fixedUpdateListener)
                _fixedTickables.Remove(fixedUpdateListener);
            
            _listeners.Remove(listener);
        }

        public void Tick()
        {
            if (_gameState == GameState.PLAYING)
            {
                var delta = Time.deltaTime;
            
                foreach (var tickable in _tickables) 
                    tickable.Tick(delta);
            }
        }

        public void FixedTick()
        {
            if (_gameState == GameState.PLAYING)
            {
                var delta = Time.fixedDeltaTime;
                
                foreach (var fixedTickable in _fixedTickables)
                    fixedTickable.FixedTick(delta);
            }
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