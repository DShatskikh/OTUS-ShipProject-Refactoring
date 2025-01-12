using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameCycle
{
    public sealed class GameKernel : MonoKernel,
        IGameStartListener,
        IGamePauseListener, 
        IGameResumeListener,
        IGameFinishListener
    {
        [Inject]
        private GameStateController _gameStateController;
        
        [InjectLocal]
        private List<IGameListener> _listeners;

        [Inject(Optional = true, Source = InjectSources.Local)]
        private List<IGameTickableListener> _tickables;
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private List<IGameFixedUpdateListener> _fixedTickables;

        public override void Start()
        {
            base.Start();
            _gameStateController.AddListener(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _gameStateController.RemoveListener(this);
        }

        public override void Update()
        {
            base.Update();

            if (_gameStateController.GetState == GameState.PLAYING)
            {
                var delta = Time.deltaTime;
            
                foreach (var tickable in _tickables) 
                    tickable.Tick(delta);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (_gameStateController.GetState == GameState.PLAYING)
            {
                var delta = Time.fixedDeltaTime;
                
                foreach (var fixedTickable in _fixedTickables)
                    fixedTickable.FixedTick(delta);
            }
        }

        public void OnStartGame()
        {
            foreach (var listener in _listeners) 
            {
                if (listener is IGameStartListener startListeners) 
                    startListeners.OnStartGame();
            }
        }

        public void OnPauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGamePauseListener pauseListeners) 
                    pauseListeners.OnPauseGame();
            } 
        }

        public void OnResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameResumeListener resumeListeners) 
                    resumeListeners.OnResumeGame();
            }
        }

        public void OnFinishGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameFinishListener finishListeners) 
                    finishListeners.OnFinishGame();
            }
        }
    }
}