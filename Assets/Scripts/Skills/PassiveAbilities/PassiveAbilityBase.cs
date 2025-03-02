using UnityEngine;

namespace Game
{
    public abstract class PassiveAbilityBase : ScriptableObject
    {
        public abstract void Activate(UnitsManager manager);
    }
}