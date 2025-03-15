using UnityEngine;

namespace Lessons.Lesson_Components
{
    public interface ITakeDamageProxy
    {
        void TakeDamage(int takeDamage);
    }

    public class TakeDamageProxy : MonoBehaviour, ITakeDamageProxy
    {
        [SerializeField] private LifeComponent _lifeComponent;
        
        public void TakeDamage(int takeDamage)
        {
            _lifeComponent.TakeDamage(takeDamage);
        }
    }
}