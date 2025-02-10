using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class DestroyToZeroHitPointsBehaviour : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var hitPoints = entity.GetHitPoints();

            hitPoints.Subscribe(points =>
            {
                if (points <= 0)
                    Object.Destroy(entity.GetRoot().gameObject);
            });
        }
    }
}