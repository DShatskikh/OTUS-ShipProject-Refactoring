using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public class BulletInstaller : EntityInstaller
    {
        [SerializeField]
        private float _moveSpeed = 5.0f;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new Bullet());
            entity.AddData(new MoveSpeed() {Value = _moveSpeed});
            entity.AddData(new Root() {Value = transform});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}