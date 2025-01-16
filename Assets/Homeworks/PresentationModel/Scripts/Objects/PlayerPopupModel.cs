using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupModel : IPlayerPopupModel
    {
        private readonly PlayerLevel _level;

        private readonly ReactiveProperty<Sprite> _icon = new();
        private readonly ReactiveProperty<string> _name = new();
        private readonly ReactiveProperty<string> _description = new();
        private readonly ReactiveProperty<string> _currentLevel = new();
        private readonly ReactiveProperty<bool> _canLevelUp = new();
        private readonly ReactiveProperty<string> _levelProgress = new();
        private readonly ReactiveProperty<float> _maxExpProgress = new();
        private readonly ReactiveProperty<float> _currentExpProgress = new();
        private readonly ReactiveCollection<CharacterStat> _stats;

        public IReadOnlyReactiveProperty<Sprite> Icon => _icon;
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<string> Level => _currentLevel;
        public IReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        public IReadOnlyReactiveProperty<string> LevelProgress => _levelProgress;
        public IReadOnlyReactiveProperty<float> MaxExpProgress => _maxExpProgress;
        public IReadOnlyReactiveProperty<float> CurrentExpProgress => _currentExpProgress;
        public IReadOnlyReactiveCollection<CharacterStat> Stats => _stats;


        public PlayerPopupModel(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel)
        {
            _level = playerLevel;

            userInfo.Icon.Subscribe(icon =>
            {
                _icon.Value = icon;
            });

            userInfo.Name.Subscribe(namePlayer =>
            {
                _name.Value = namePlayer;
            });
            
            userInfo.Description.Subscribe(description =>
            {
                _description.Value = description;
            });
            
            _level.Experience.Subscribe(exp =>
            {
                _currentExpProgress.Value = exp;
                _maxExpProgress.Value = _level.RequiredExperience;
                _levelProgress.Value = $"XP: {exp}/{_level.RequiredExperience}";
                _canLevelUp.Value = _level.CanLevelUp();
            });
            
            _level.Level.Subscribe(level =>
            {
                _currentLevel.Value = $"Level: {_level.Level.Value}";
                _levelProgress.Value = $"XP: {_level.Experience}/{_level.RequiredExperience}";
            });

            _stats = new ReactiveCollection<CharacterStat>(characterInfo.Stats);
            
            characterInfo.Stats.ObserveAdd().Subscribe(stat =>
            {
                _stats.Add(stat.Value);
            });
            
            characterInfo.Stats.ObserveRemove().Subscribe(stat =>
            {
                _stats.Remove(stat.Value);
            });
        }

        public void LevelUp() => 
            _level.LevelUp();
    }
}