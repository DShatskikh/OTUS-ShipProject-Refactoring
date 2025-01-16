using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupModel : IPlayerPopupModel, IDisposable
    {
        private readonly UserInfo _userInfo;
        private readonly CharacterInfo _characterInfo;
        private readonly PlayerLevel _level;

        public Sprite GetIcon => _userInfo.Icon;
        public string GetName => _userInfo.Name;
        public string GetDescription => _userInfo.Description;
        public string GetLevel => $"Level: {_level.CurrentLevel}";
        public string GetProgress => $"XP: {_level.CurrentExperience}/{_level.RequiredExperience}";
        public float GetMaxExp => _level.RequiredExperience;
        public float GetCurrentExp => _level.CurrentExperience;
        public bool CanLevelUp => _level.CanLevelUp();
        public CharacterStat[] GetStats => _characterInfo.GetStats();
        public event Action<Sprite> UpgradeIcon;
        public event Action<string> UpgradeName;
        public event Action<string> UpgradeDescription;
        public event Action<string> UpgradeLevel;
        public event Action<string, float, float> UpgradeExperience;
        public event Action<bool> OnCanLevelUp;
        public event Action<CharacterStat> StatAdded;
        public event Action<CharacterStat> StatRemoved;

        public PlayerPopupModel(UserInfo userInfo, CharacterInfo characterInfo, PlayerLevel playerLevel)
        {
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _level = playerLevel;

            _userInfo.OnIconChanged += OnIconChanged;
            _userInfo.OnNameChanged += OnUpgradeName;
            _userInfo.OnDescriptionChanged += OnUpgradeDescription;
            _level.OnLevelUp += OnUpgradeLevel;
            _level.OnExperienceChanged += OnUpgradeExperience;
            _characterInfo.OnStatAdded += OnStatAdded;
            _characterInfo.OnStatRemoved += OnStatRemoved;
        }


        public void Dispose()
        {
            _userInfo.OnIconChanged -= OnIconChanged;
            _userInfo.OnNameChanged -= OnUpgradeName;
            _userInfo.OnDescriptionChanged -= OnUpgradeDescription;
            _level.OnLevelUp -= OnUpgradeLevel;
            _level.OnExperienceChanged -= OnUpgradeExperience;
        }

        public void LevelUp() => 
            _level.LevelUp();

        private void OnIconChanged(Sprite sprite) => 
            UpgradeIcon?.Invoke(sprite);

        private void OnUpgradeName(string text) => 
            UpgradeName?.Invoke(text);

        private void OnUpgradeDescription(string text) => 
            UpgradeDescription?.Invoke(text);

        private void OnUpgradeLevel()
        {
            UpgradeLevel?.Invoke(GetLevel);
            UpgradeExperience?.Invoke(GetProgress, GetMaxExp, GetCurrentExp);
            OnCanLevelUp?.Invoke(CanLevelUp);
        }

        private void OnUpgradeExperience(int currentExp)
        {
            UpgradeExperience?.Invoke(GetProgress, GetMaxExp, currentExp);
            OnCanLevelUp?.Invoke(CanLevelUp);
        }

        private void OnStatAdded(CharacterStat stat) => 
            StatAdded?.Invoke(stat);

        private void OnStatRemoved(CharacterStat stat) => 
            StatRemoved?.Invoke(stat);
    }
}