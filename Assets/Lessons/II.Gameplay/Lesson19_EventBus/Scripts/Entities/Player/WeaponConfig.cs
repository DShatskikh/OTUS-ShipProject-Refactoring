using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    [CreateAssetMenu(
        fileName = "WeaponConfig",
        menuName = "Lesson/EventBus/New WeaponConfig"
    )]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeReference]
        public List<IWeaponEffect> Effects = new();
    }

    public interface IWeaponEffect
    {
        IEntity Source { get; set; }
        IEntity Target { get; set; }
    }

    public class ForceWeaponEffect : IWeaponEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}