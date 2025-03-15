using System;
using UnityEngine;

namespace Lessons.Lesson_Components
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITakeDamageProxy takeDamageProxy))
            {
                takeDamageProxy.TakeDamage(_damage);
            }
        }
    }
}