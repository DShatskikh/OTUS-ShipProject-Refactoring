using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Lesson_AtomicPractice
{
    public class ResourceStorage : MonoBehaviour
    {
        private readonly Dictionary<ResourceType, int> _resources = new();
        
        public void AddResource(ResourceType resourceType, int range)
        {
            _resources[resourceType] += range;
            Debug.Log($"Add resource {resourceType}: {range}");
        }
    }
}