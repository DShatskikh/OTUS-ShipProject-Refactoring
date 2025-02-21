using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class RotateToSeePointBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _rootVisual;
        private float _rotateSpeed;

        public void Init(IEntity entity)
        {
            _rootVisual = entity.GetRootVisual();
            _rotateSpeed = entity.GetRotationSpeed();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var seePoint = entity.GetSeePoint();
            var direction = Vector3.Normalize(seePoint - _rootVisual.position);
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            
            _rootVisual.eulerAngles = new Vector3(0,
                Quaternion.Lerp(_rootVisual.rotation, targetRotation, _rotateSpeed * Time.deltaTime)
                    .eulerAngles.y, 0);
        }
    }
}