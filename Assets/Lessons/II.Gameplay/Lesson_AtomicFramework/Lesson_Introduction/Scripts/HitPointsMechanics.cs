using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class HitPointsMechanics : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var hitPoints = entity.GetHitPoints();
            hitPoints.Subscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            Debug.Log($"Hit points changed = {hitPoints}");
        }
    }
}