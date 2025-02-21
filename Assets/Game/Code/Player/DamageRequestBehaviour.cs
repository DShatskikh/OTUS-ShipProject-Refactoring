using Atomic.Entities;

namespace Game
{
    public class DamageRequestBehaviour : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var request = entity.GetDamageRequest();
            
            request.Subscribe(damage =>
            {
                entity.GetHitPoints().Value -= 1;
            });
        }
    }
}