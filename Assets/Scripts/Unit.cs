using System;
using System.Collections.Generic;
using DG.Tweening;
using UI;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Game
{
    public class Unit : MonoBehaviour
    {
        [SerializeField]
        private UnitConfig _config;

        [SerializeField]
        private HeroView _view;
        
        [SerializeField]
        private ParticleSystem _damageVfx;
        
        private int _attack;
        private int _health;
        private int _previousHealth;
        private List<SkillBase> _skills;
        private bool _isFreeze;
        private UnitsManager _unitsManager;

        public event Action<Unit> Select;
        public int GetAttack => _attack;
        public HeroView GetView => _view;
        public List<SkillBase> GetSkills => _skills;
        public bool GetFreeze => _isFreeze;
        public UnitConfig GetConfig => _config;
        public int GetHealth => _health;
        public int GetPreviousHealth => _previousHealth;

        [Inject]
        private void Construct(UnitsManager unitsManager)
        {
            _unitsManager = unitsManager;
        }
        
        private void Awake()
        {
            _view.OnClicked += OnClick;
            
            _view.ToggleButtonInteractable(false);
            _view.SetIcon(_config.GetSprite);
            _view.SetStats($"{_config.GetAttack}/{_config.GetHealth}");

            _attack = _config.GetAttack;
            _health = _config.GetHealth;
            _skills = _config.GetSkill;
        }

        public void ToggleSelect(bool value)
        {
            if (value && _config.GetStartTurnSounds.Length != 0)
            {
                AudioPlayer.Instance
                    .PlaySound(_config.GetStartTurnSounds[Random.Range(0, _config.GetStartTurnSounds.Length)]); 
            }

            _view.SetActive(value);
        }

        private void OnClick() => 
            Select?.Invoke(this);

        public void ToggleInteractable(bool value) => 
            _view.ToggleButtonInteractable(value);

        public void HealthSubtract(int value)
        {
            _previousHealth = _health;
            _health -= value;
        }

        public void UpgradeStats() => 
            _view.SetStats($"{_attack}/{_health}");

        public void AnimationUpgradeStats()
        {
            if (_previousHealth == _health)
                return;
            
            var sequence = DOTween.Sequence();
            sequence
                .Append(_view.GetStats.transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBounce))
                .Append(DOTween.To(health => _view.SetStats($"{_attack}/{(int)health}"), _previousHealth, _health, 1f)
                .SetEase(Ease.Linear))
                .Append(_view.GetStats.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce))
                .OnComplete(() => _previousHealth = _health);
        }

        public void HealthAdd(int value)
        {
            _previousHealth = _health;
            _health += value;
        }

        public void RemoveSkill() => 
            _skills = null;

        public void SetFreeze(bool value) => 
            _isFreeze = value;

        public void ActivatePassiveAbility()
        {
            if (_config.GetPassiveAbilities == null)
                return;
            
            foreach (var ability in _config.GetPassiveAbilities) 
                ability.Activate(_unitsManager);
        }

        public void PlayDamageEffect()
        {
            if (_damageVfx == null)
                return;
            
            _damageVfx.Play();
        }
    }
}