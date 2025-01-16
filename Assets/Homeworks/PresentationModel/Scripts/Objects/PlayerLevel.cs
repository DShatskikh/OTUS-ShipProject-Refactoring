using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevel
    {
        [ShowInInspector]
        private ReactiveProperty<int> _experience = new();
        
        [ShowInInspector]
        private ReactiveProperty<int> _level = new();
        
        public IReadOnlyReactiveProperty<int> Experience => _experience;
        public IReadOnlyReactiveProperty<int> Level => _level;

        [ShowInInspector, ReadOnly]
        public int RequiredExperience => 100 * (_level.Value + 1);

        public PlayerLevel()
        {
            _level.Value = 1;
        }
        
        [Button]
        public void AddExperience(int range)
        {
            var xp = Math.Min(_experience.Value + range, RequiredExperience);
            _experience.Value = xp;
        }

        [Button]
        public void LevelUp()
        {
            if (CanLevelUp())
            {
                _experience.Value = 0;
                _level.Value++;
            }
        }

        public bool CanLevelUp() => 
            _experience.Value == RequiredExperience;
    }
}