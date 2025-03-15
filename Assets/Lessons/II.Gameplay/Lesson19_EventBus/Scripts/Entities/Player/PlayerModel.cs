using System;
using Declarative;

namespace Lessons.Lesson19_EventBus
{
    public sealed class PlayerModel : DeclarativeModel
    {
        [Section]
        public Position position;

        [Section]
        public Stats stats;

        public Weapon Weapon;
    }

    [Serializable]
    public class Weapon
    {
        public WeaponConfig WeaponConfig;
    }
}