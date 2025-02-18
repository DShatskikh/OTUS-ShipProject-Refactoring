using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public class EnemyInstaller : EntityInstaller
    {
        [SerializeField]
        private CommandColor _commandColor;
        
        protected override void Install(Entity entity)
        {
            
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}