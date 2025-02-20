using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ArrowInstaller : EntityInstaller
    {
        [SerializeField]
        private float _speed = 3;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new ArrowTag());
            entity.AddData(new MoveSpeed() { Value = _speed });
            entity.AddData(new Root() { Value = transform });
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}