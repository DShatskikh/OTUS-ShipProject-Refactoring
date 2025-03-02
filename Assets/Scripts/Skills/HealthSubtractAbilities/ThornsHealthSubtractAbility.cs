using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ThornsHealthSubtractAbility", menuName = "Skills/HealthSubtract/ThornsHealthSubtractAbility", order = 98)]
    public sealed class ThornsHealthSubtractAbility : HealthSubtractAbility
    {
        [SerializeField]
        private int _damage = 1;
        
        public override void Activate(UnitsManager manager, EventBus eventBus)
        {
            foreach (var enemy in manager.GetTurnEnemyUnits) 
                eventBus.RaiseEvent(new DamageEvent(enemy, _damage));
        }
    }
}