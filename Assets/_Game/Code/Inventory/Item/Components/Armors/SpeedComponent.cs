using System;
using System.Linq;
using Game.Systems;
using UnityEngine;
using Zenject;

namespace Game.Inventory
{
    [Serializable]
    public sealed class SpeedComponent : IItemComponent
    {
        public int Speed;

        public IItemComponent Clone()
        {
            return new SpeedComponent()
            {
                Speed = Speed
            };
        }
    }
}