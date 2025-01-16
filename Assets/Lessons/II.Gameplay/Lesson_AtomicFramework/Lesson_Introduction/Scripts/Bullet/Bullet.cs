using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private MoveComponent _moveComponent;

        private void Update()
        {
            _moveComponent.OnUpdate(Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITakeDamageProxy proxy))
            {
                proxy.TakeDamage(_damage);
            }
        }
        
        public void SetDirection(Vector3 moveDirection)
        {
            _moveComponent.SetDirection(moveDirection);
        }
    }
}