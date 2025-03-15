using UnityEngine;

namespace Lessons.Lesson_AtomicPractice
{
    public class DetectResourceUseCases
    {
        public static bool TryFindNearestResource(Vector3 position, float radius, out SceneResource sceneResource)
        {
            var colliders = new Collider[10];
            var count = Physics.OverlapSphereNonAlloc(position, radius, colliders);

            sceneResource = null;
            float minDistance = float.MaxValue;

            for (int i = 0; i < count; i++)
            {
                var collider = colliders[i];

                if (!collider.TryGetComponent(out SceneResource resource))
                {
                    continue;
                }
                
                var targetDistance = Vector3.Distance(position, resource.transform.position);
                    
                if (targetDistance <= minDistance)
                {
                    sceneResource = resource;
                }
            }

            return sceneResource != null;
        }
    }
}