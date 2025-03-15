using DG.Tweening;
using Entities;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class MoveVisualTask : EventTask
    {
        private readonly IEntity _evtEntity;
        private Vector3 _position;
        
        public MoveVisualTask(IEntity evtEntity, Vector3 position)
        {
            _evtEntity = evtEntity;
            _position = position;
        }

        protected override void OnStart()
        {
            var entityTransform = _evtEntity.Get<TransformComponent>();
            entityTransform.Value.DOMove(_position, .3f).OnComplete(Complete)
                .SetLink(entityTransform.Value.gameObject);
        }
    }
}