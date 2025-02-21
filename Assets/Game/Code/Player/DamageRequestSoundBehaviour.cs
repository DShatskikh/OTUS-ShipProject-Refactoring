using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public class DamageRequestSoundBehaviour : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var request = entity.GetDamageRequest();
            var sound = entity.GetDamageSoundPlayer();
            
            request.Subscribe(damage =>
            {
                sound.Play();
                Debug.Log("Sound");
            });
        }
    }
}