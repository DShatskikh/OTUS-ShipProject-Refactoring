using System;
using Entities;
using UnityEngine;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public sealed class MoveHandler : BaseEventHandler<MoveEvent>
    {
        private readonly LevelMap _levelMap;

        public MoveHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void OnEventInvoked(MoveEvent evt)
        {
            var entity = evt.Entity;
            var direction = evt.Direction;
            
            var coordinates = entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + direction;
            
            _levelMap.Entities.RemoveEntity(coordinates.Value);
            _levelMap.Entities.SetEntity(targetCoordinates, entity);
            coordinates.Value = targetCoordinates;

            var position = entity.Get<PositionComponent>();
            position.Value = _levelMap.Tiles.CoordinatesToPosition(targetCoordinates);

            if (!_levelMap.Tiles.IsWalkable(targetCoordinates))
            {
                EventBus.RaiseEvent(new DestroyEvent(entity));
            }
        }
    }

    public class MoveEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public MoveEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}