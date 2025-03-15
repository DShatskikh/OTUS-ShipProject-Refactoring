using System;
using UnityEngine;

namespace Lessons.Lesson_Components
{
    //Facade
    public class Character : MonoBehaviour
    {
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotateComponent _rotateComponent;
        [SerializeField] private ShootComponent _shootComponent;
        
        private void Awake()
        {
            //Устанавливаем
            var canMove = new CompositeCondition();
            canMove.AppendCondition(_lifeComponent.IsAlive);
            canMove.AppendCondition(() => _moveComponent.DebugCanMove);
            _moveComponent.Construct(canMove);
            
            _rotateComponent.CanRotate.AppendCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            _moveComponent.Update();
        }

        public void Shoot()
        {
            _shootComponent.Shoot();
        }

        public void SetDirection(Vector3 direction)
        {
            _moveComponent.SetDirection(direction);
        }
    }
}