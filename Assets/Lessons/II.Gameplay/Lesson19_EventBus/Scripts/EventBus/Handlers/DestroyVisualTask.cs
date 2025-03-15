using DG.Tweening;
using Entities;

namespace Lessons.Lesson19_EventBus
{
    public class DestroyVisualTask : EventTask
    {
        public IEntity Entity;

        public DestroyVisualTask(IEntity entity)
        {
            Entity = entity;
        }

        protected override void OnStart()
        {
            var transformComponent = Entity.Get<TransformComponent>();
            transformComponent.Value.DOScale(0f, 1f)
                .OnComplete(Complete).SetLink(transformComponent.Value.gameObject);
        }
    }
}