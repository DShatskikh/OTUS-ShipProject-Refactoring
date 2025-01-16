using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private ShootComponent _shootComponent;

        [SerializeField] private Transform _targetPoint;
        [SerializeField] private float _radius;

        private void Awake()
        {
            _rotationComponent.AddCondition(_lifeComponent.IsAlive);
            _shootComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            _shootComponent.OnUpdate(Time.deltaTime);
            
            var direction = _targetPoint.position - transform.position;
            _rotationComponent.Rotate(direction);

            if (direction.magnitude < _radius)
            {
                _shootComponent.Shoot();
            }
        }
    }
}