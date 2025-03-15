using System;
using UnityEngine;

namespace Game.Meta
{
    public interface IUpgrade
    {
        int GetPrice { get; }
        int GetLevel { get; }
        int GetMaxLevel { get; }
        bool CanLevelUp { get; }
        SawmillUpgradeMetadata Metadata { get; }
        event Action<int> OnLevelUp;
        bool IsMaxLevel { get; }
        int NextImprovement { get; }
        string CurrentStats { get; }
        void LevelUp();
    }
}