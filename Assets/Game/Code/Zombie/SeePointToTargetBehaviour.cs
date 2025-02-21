using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public class SeePointToTargetBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _target;

        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            entity.SetSeePoint(_target.position);
        }
    }
}