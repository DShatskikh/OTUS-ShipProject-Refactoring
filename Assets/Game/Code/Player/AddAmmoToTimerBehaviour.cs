using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    public sealed class AddAmmoToTimerBehaviour : IEntityInit, IEntityUpdate
    {
        private const float TARGET_DURATION = 2f;
        
        private ReactiveInt _ammo;
        private int _maxAmmo;
        private float _timer = 0f;

        public void Init(IEntity entity)
        {
            _ammo = entity.GetAmmo();
            _maxAmmo = entity.GetMaxAmmo();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_timer >= TARGET_DURATION)
            {
                if (_ammo.Value >= _maxAmmo)
                    return;
                
                _ammo.Value += 1;
                _timer = 0;
            }
            else
            {
                _timer += deltaTime;
            }
        }
    }
}