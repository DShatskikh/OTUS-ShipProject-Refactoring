using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _sceneEntity;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _sceneEntity.GetShootAction().Invoke();
            }
        }
    }
}