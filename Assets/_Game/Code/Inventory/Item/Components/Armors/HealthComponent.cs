using System;
using Game.Systems;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class HealthComponent : IItemComponent
    {
        public int Health;

        public IItemComponent Clone()
        {
            return new HealthComponent()
            {
                Health = Health
            };
        }
    }
}