using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class SwordInstaller : EntityInstaller
    {
        [SerializeField]
        private int _damage;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new SwordTag());
            entity.AddData(new Damage() { Value = _damage });
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}