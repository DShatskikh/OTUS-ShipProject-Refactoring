using System;
using Game.Meta;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_HeroUpgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        public string Id;
        public int MaxLevel;
        public UpgradePriceTable PriceTable;

        public abstract Upgrade Create();

        public int GetNextPrice(int level)
        {
            return PriceTable.GetPrice(level);
        }

        protected virtual void OnValidate()
        {
            PriceTable.OnValidate(MaxLevel);
        }
    }
}