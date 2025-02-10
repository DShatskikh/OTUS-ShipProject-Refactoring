using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CameraMoveToTargetBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _root;
        private Transform _target;
        
        void IEntityInit.Init(IEntity entity)
        {
            _root = entity.GetRoot();
            _target = entity.GetTarget();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            var targetPosition = _target.position;
            _root.position = new Vector3(targetPosition.x, _root.position.y, targetPosition.z);
        }
    }
}