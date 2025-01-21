using System;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupModel : IPlayerPopupModel, IDisposable
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
        private readonly PopupManager _popupManager;

        public IReadOnlyReactiveProperty<Sprite> Icon => _icon;
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<string> Level => _currentLevel;
        public IReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        public IReadOnlyReactiveProperty<string> LevelProgress => _levelProgress;
        public IReadOnlyReactiveProperty<float> MaxExpProgress => _maxExpProgress;
        public IReadOnlyReactiveProperty<float> CurrentExpProgress => _currentExpProgress;
        public IReadOnlyReactiveCollection<CharacterStat> Stats => _stats;
        
        public PlayerPopupModel(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel, 
            PopupManager popupManager)
        {
            _level = playerLevel;
            _popupManager = popupManager;

            userInfo.Icon.SubscribeToReactiveProperty(_icon);
            userInfo.Name.SubscribeToReactiveProperty(_name);
            userInfo.Description.SubscribeToReactiveProperty(_description);
            
            _level.Experience.Subscribe(exp =>
            {
                _maxExpProgress.Value = _level.RequiredExperience;
                _currentExpProgress.Value = exp;
                _levelProgress.Value = $"XP: {exp}/{_level.RequiredExperience}";
                _canLevelUp.Value = _level.CanLevelUp();
            });
            
            _level.Level.Subscribe(level =>
            {
                _currentLevel.Value = $"Level: {_level.Level.Value}";
                _levelProgress.Value = $"XP: {_level.Experience}/{_level.RequiredExperience}";
            });

            _stats = new ReactiveCollection<CharacterStat>(characterInfo.Stats);
            
            characterInfo.Stats.ObserveAdd().Subscribe(stat => _stats.Add(stat.Value));
            characterInfo.Stats.ObserveRemove().Subscribe(stat => _stats.Remove(stat.Value));
        }

        public void LevelUp() => 
            _level.LevelUp();

        public void Hide() => 
            _popupManager.Hide(PopupType.PlayerPopup);

        public void Dispose()
        {
            _icon?.Dispose();
            _name?.Dispose();
            _description?.Dispose();
            _currentLevel?.Dispose();
            _canLevelUp?.Dispose();
            _levelProgress?.Dispose();
            _maxExpProgress?.Dispose();
            _currentExpProgress?.Dispose();
            _stats?.Dispose();
        }
    }
}