using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Configs/UnitConfig", fileName = "UnitConfig", order = 51)]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField]
        private int _attack;
        
        [SerializeField]
        private int _health;
        
        [SerializeField]
        private Sprite _sprite;

        [Header("Audio Effects")]
        [SerializeField]
        private AudioClip[] _startTurnSounds;

        [SerializeField]
        private AudioClip _lowHealthSound;

        [SerializeField]
        private AudioClip _deathSound;
        
        [Header("Skills")]
        [SerializeField]
        private List<SkillBase> _skill;

        [SerializeField]
        public List<HealthSubtractAbility> _healthSubtractAbilities;
        
        [SerializeField]
        public List<PassiveAbilityBase> _passiveAbilities;
        
        public int GetAttack => _attack;
        public int GetHealth => _health;
        public Sprite GetSprite => _sprite;
        public List<SkillBase> GetSkill => _skill;
        public List<HealthSubtractAbility> GetHealthSubtractAbilities => _healthSubtractAbilities;
        public List<PassiveAbilityBase> GetPassiveAbilities => _passiveAbilities;
        public AudioClip[] GetStartTurnSounds => _startTurnSounds;
        public AudioClip GetLowHealthSound => _lowHealthSound;
        public AudioClip GetDeathSound => _deathSound;
    }
}