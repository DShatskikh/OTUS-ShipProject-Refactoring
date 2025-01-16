using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IPlayerPopupModel
    {
        Sprite GetIcon { get; }
        string GetName { get; }
        string GetDescription { get; }
        string GetLevel { get; }
        string GetProgress { get; }
        float GetMaxExp { get; }
        float GetCurrentExp { get; }
        bool CanLevelUp { get; }
        CharacterStat[] GetStats { get; }
        event Action<Sprite> UpgradeIcon;
        event Action<string> UpgradeName;
        event Action<string> UpgradeDescription;
        event Action<string> UpgradeLevel;
        event Action<string, float, float> UpgradeExperience;
        event Action<bool> OnCanLevelUp;
        event Action<CharacterStat> StatAdded;
        event Action<CharacterStat> StatRemoved;
        void LevelUp();
    }
}