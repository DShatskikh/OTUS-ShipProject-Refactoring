using System;
using Entities;
using UnityEngine;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public sealed class ApplyDirectionHandler : BaseEventHandler<ApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ApplyDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void OnEventInvoked(ApplyDirectionEvent evt)
        {
            var entity = evt.Entity;
            var direction = evt.Direction;
            
            var coordinates = entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + direction;

            if (_levelMap.Entities.HasEntity(targetCoordinates))
            {
                var target = _levelMap.Entities.GetEntity(targetCoordinates);
                EventBus.RaiseEvent(new AttackEvent(entity, target));
                return;
            }
            
            if (_levelMap.Tiles.IsWalkable(targetCoordinates))
            {
                EventBus.RaiseEvent(new MoveEvent(entity, direction));
            }
        }
    }

    public class ApplyDirectionEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int Direction;

        public ApplyDirectionEvent(IEntity entity, Vector2Int direction)
        {
            Entity = entity;
            Direction = direction;
        }
    }
}