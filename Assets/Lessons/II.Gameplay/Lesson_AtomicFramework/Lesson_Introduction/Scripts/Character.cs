using Atomic.Elements;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class Character : MonoBehaviour, IMoveable
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private ShootComponent _shootComponent;

        public ReactiveVariable<int> HitPoints;
        public ReactiveVariable<bool> IsDead;
        
        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _rotationComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _moveComponent.OnUpdate(deltaTime);
            _shootComponent.OnUpdate(deltaTime);
        }

        public void SetDirection(Vector3 moveDirection)
        {
            _moveComponent.SetDirection(moveDirection);
        }

        public void Rotate(Vector3 direction)
        {
            _rotationComponent.Rotate(direction);
        }

        public void Shoot()
        {
            _shootComponent.Shoot();
        }
    }

    public interface IMoveable
    {
        void SetDirection(Vector3 moveDirection);
    }
}