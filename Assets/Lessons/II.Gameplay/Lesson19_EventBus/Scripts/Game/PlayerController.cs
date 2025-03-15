using System;
using Entities;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public sealed class PlayerInputTask : EventTask
    {
        private KeyboardInput _input;
        private EventBus _eventBus;
        private IEntity _player;

        [Inject]
        public void Construct(
            KeyboardInput input, 
            EventBus eventBus, 
            PlayerService playerService)
        {
            _input = input;
            _eventBus = eventBus;
            _player = playerService.Player;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            _input.MovePerformed -= OnMovePreformed;

            var applyDirectionEvent = new ApplyDirectionEvent(_player, direction);
            _eventBus.RaiseEvent(applyDirectionEvent);
        }

        protected override void OnStart()
        {
            _input.MovePerformed += OnMovePreformed;
        }
    }
}