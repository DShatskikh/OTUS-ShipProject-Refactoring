using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public enum GameState
    {
        Off = 0,
        Playing = 1,
        Pause = 2,
        Finished = 3,
    }
    
    public class GameCycle : MonoBehaviour
    {
        [ReadOnly]
        public GameState State;

        public float Multiplier = 1.5f;
        
        private List<IGameListener> _gameListeners = new();

        private List<IGameUpdateListener> _gameUpdateListeners = new();
        private List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();
        private List<IGameLateUpdateListener> _gameLateUpdateListeners = new();

        private void Awake()
        {
            _gameListeners = GetComponentsInChildren<IGameListener>().ToList();

            foreach (var gameListener in _gameListeners)
            {
                AddListener(gameListener);
            }
        }

        private void Update()
        {
            if (State == GameState.Playing || State == GameState.Pause)
            {
                UpdateGame();
            }
        }

        private void FixedUpdate()
        {
            FixedUpdateGame();
        }

        private void LateUpdate()
        {
            LateUpdateGame();
        }

        private void AddListener(IGameListener gameListener)
        {
            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _gameUpdateListeners.Add(gameUpdateListener);
            }
            
            if(gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _gameFixedUpdateListeners.Add(gameFixedUpdateListener);    
            }

            if (gameListener is IGameLateUpdateListener gameLateUpdateListener)
            {
                _gameLateUpdateListeners.Add(gameLateUpdateListener);
            }
        }

        [Button]
        private void StartGame()
        {
            if (State == GameState.Playing || State == GameState.Pause)
            {
                Debug.Log("Game is already started!");
                return;
            }
            
            State = GameState.Playing;
            
            for (int i = 0; i < _gameListeners.Count; i++)
            {
                if (_gameListeners[i] is IGameStartListener gameStartListener)
                {
                    gameStartListener.OnStartGame();
                }
            }
        }

        [Button]
        private void FinishGame()
        {
            if (State == GameState.Off || State == GameState.Finished)
            {
                Debug.Log("Game is already finished!");
                return;
            }
            
            State = GameState.Finished;

            for (int i = 0; i < _gameListeners.Count; i++)
            {
                if (_gameListeners[i] is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }
        }

        [Button]
        private void PauseGame()
        {
            if (State == GameState.Off || State == GameState.Finished || State == GameState.Pause)
            {
                Debug.Log("Game is already finished!");
                return;
            }
            
            State = GameState.Pause;

            for (int i = 0; i < _gameListeners.Count; i++)
            {
                if (_gameListeners[i] is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnPauseGame();
                }
            }
        }

        [Button]
        private void ResumeGame()
        {
            if (State == GameState.Playing || State == GameState.Off)
            {
                Debug.Log("Game is not on pause!");
                return;
            }
            
            State = GameState.Playing;

            for (int i = 0; i < _gameListeners.Count; i++)
            {
                if (_gameListeners[i] is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnResumeGame();
                }
            }
        }

        public void UpdateGame()
        {
            float deltaTime = Time.deltaTime * Multiplier;

            for (int i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].OnUpdate(deltaTime);
            }
        }

        public void FixedUpdateGame()
        {
            float deltaTime = Time.fixedDeltaTime;

            for (int i = 0; i < _gameFixedUpdateListeners.Count; i++)
            {
                _gameFixedUpdateListeners[i].OnFixedUpdate(deltaTime);
            }
        }
        
        public void LateUpdateGame()
        {
            float deltaTime = Time.deltaTime;

            for (int i = 0; i < _gameLateUpdateListeners.Count; i++)
            {
                _gameLateUpdateListeners[i].OnLateUpdate(deltaTime);
            }
        }
    }
}