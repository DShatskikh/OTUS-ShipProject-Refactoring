using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Meta
{
    public abstract class SawmillUpgrade : IUpgrade
    {
        [SerializeField]
        protected List<int> _prices;

        [SerializeField]
        private SawmillUpgradeMetadata _metadata;
        
        protected int _index;

        public SawmillUpgradeMetadata Metadata => _metadata;
        public int GetPrice => _index >= _prices.Count ? _prices[^1] : _prices[_index];
        public int GetLevel => _index + 1;
        public int GetMaxLevel => _prices.Count + 1;
        public abstract int NextImprovement { get; }

        public bool CanLevelUp
        {
            get
            {
                if (_index < _prices.Count && _prices[_index] < 100)
                    return true;

                return false;
            }
        }

        public bool IsMaxLevel => _index >= _prices.Count;
        public abstract event Action<int> OnLevelUp;
        public abstract string CurrentStats { get; }
        public abstract void LevelUp();
    }
}