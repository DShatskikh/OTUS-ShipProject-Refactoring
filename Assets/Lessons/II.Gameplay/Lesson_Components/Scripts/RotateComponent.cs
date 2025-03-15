using UnityEngine;

namespace Lessons.Lesson_Components
{
    public class RotateComponent : MonoBehaviour
    {
        public Transform RotationRoot => _rotationRoot;
        
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform _rotationRoot;

        public CompositeCondition CanRotate { get; } = new CompositeCondition();

        private Vector3 _rotateDirection;
        
        public void Update()
        {
            Rotate();
        }

        public void SetRotationDirection(Vector3 direction)
        {
            _rotateDirection = direction;
        }

        public void Rotate()
        {
            if (!CanRotate.Invoke())
            {
                return;
            }
            
            if (_rotateDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateSpeed);
        }
    }
}