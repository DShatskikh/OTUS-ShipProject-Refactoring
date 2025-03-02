using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AddHealthRandomPassiveAbility", menuName = "Skills/PassiveAbility/AddHealthRandomPassiveAbility", order = 99)]
    public sealed class AddHealthRandomIPassiveAbility : PassiveAbilityBase
    {
        [SerializeField]
        private int _health = 1;

        [SerializeField]
        private AudioClip _sound;
        
        public override void Activate(UnitsManager manager)
        {
            foreach (var unit in manager.GetTurnUnits) 
                unit.HealthAdd(_health);
            
            AudioPlayer.Instance.PlaySound(_sound);
        }
    }
}