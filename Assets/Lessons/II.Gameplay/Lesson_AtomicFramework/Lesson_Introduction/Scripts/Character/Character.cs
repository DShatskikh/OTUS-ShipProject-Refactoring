using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private ShootComponent _shootComponent;

        private void Awake()
        {
            // _components.Add(new ExampleComponent());
            //
            // foreach (var logicComponent in _components)
            // {
            //     //Находим moveComponent
            //     //Находим lifeComponent
            //     if(logicComponent)
            //         
            //     //Находим rotationComponent
            //     //Находим lifeComponent
            // }
            _moveComponent.Condition.AddCondition(_lifeComponent.IsAlive);
            
            _rotationComponent.Condition.AddCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _moveComponent.OnUpdate(deltaTime);
            _shootComponent.OnUpdate(deltaTime);
        }

        public void Shoot()
        {
            _shootComponent.Shoot();
        }

        public void SetDirection(Vector3 moveDirection)
        {
            _moveComponent.SetDirection(moveDirection);
        }

        public void Rotate(Vector3 rotateDirection)
        {
            _rotationComponent.Rotate(rotateDirection);
        }
    }
}