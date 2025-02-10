using Atomic.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public sealed class RotateToMouseBehaviour : IEntityInit, IEntityUpdate
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
            float mouseX = Mouse.current.position.x.ReadValue();
            float mouseY = Mouse.current.position.y.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(mouseX, mouseY, 0));

            var mousePosition = ray.GetPoint(11);
            var direction = Vector3.Normalize(mousePosition - _rootVisual.position);
            
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _rootVisual.eulerAngles = new Vector3(0,
                Quaternion.Lerp(_rootVisual.rotation, targetRotation, _rotateSpeed * Time.deltaTime)
                    .eulerAngles.y, 0);
        }
    }
}