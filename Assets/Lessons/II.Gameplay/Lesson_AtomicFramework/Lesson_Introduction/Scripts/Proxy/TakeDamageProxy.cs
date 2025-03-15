using System;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class TakeDamageProxy : MonoBehaviour, ITakeDamageProxy
    {
        [SerializeField] private LifeComponent _lifeComponent;

        public void TakeDamage(int damage)
        {
            _lifeComponent.TakeDamage(damage);
        }
    }
}