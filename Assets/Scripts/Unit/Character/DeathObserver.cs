using System;
using Zenject;

namespace ShootEmUp
{
    public sealed class DeathObserver : IInitializable, IDisposable
    {
        private readonly ICharacter _character;
        private readonly GameStateController _gameStateController;

        public DeathObserver(ICharacter character, GameStateController gameStateController)
        {
            _character = character;
            _gameStateController = gameStateController;
        }
        
        public void Initialize()
        {
            _character.OnDeath += OnDeath;
        }

        public void Dispose()
        {
            _character.OnDeath -= OnDeath;
        }

        private void OnDeath()
        {
            _gameStateController.FinishGame();
        }
    }
}