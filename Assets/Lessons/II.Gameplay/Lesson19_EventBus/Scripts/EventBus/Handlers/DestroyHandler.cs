using Entities;

namespace Lessons.Lesson19_EventBus
{
    public sealed class DestroyHandler : BaseEventHandler<DestroyEvent>
    {
        private readonly LevelMap _levelMap;

        public DestroyHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void OnEventInvoked(DestroyEvent evt)
        {
            var entity = evt.Entity;
            
            if (entity.TryGet(out DeathComponent deathComponent))
            {
                deathComponent.Die();
            }

            var coordinates = entity.Get<CoordinatesComponent>();
            _levelMap.Entities.RemoveEntity(coordinates.Value);
            
            if (entity.TryGet(out DestroyComponent destroyComponent))
            {
                destroyComponent.Destroy();
            }
        }
    }

    public class DestroyEvent
    {
        public readonly IEntity Entity;

        public DestroyEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}