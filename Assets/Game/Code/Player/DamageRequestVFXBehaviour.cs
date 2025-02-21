using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public class DamageRequestVFXBehaviour : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var request = entity.GetDamageRequest();
            var vfx = entity.GetDamageVFX();
            
            request.Subscribe(damage =>
            {
                vfx.Play();
                Debug.Log("VFX");
            });
        }
    }
}