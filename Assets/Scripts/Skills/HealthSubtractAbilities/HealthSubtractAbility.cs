using UnityEngine;

namespace Game
{
    public abstract class HealthSubtractAbility : ScriptableObject
    {
        public abstract void Activate(UnitsManager manager, EventBus eventBus);
    }
}