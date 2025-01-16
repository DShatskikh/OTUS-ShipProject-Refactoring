using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfo
    {
        [ShowInInspector]
        private readonly ReactiveCollection<CharacterStat> _stats;
        
        public IReadOnlyReactiveCollection<CharacterStat> Stats => _stats;

        public CharacterInfo(IEnumerable<CharacterStat> stats)
        {
            _stats = new ReactiveCollection<CharacterStat>(stats);
        }

        [Button]
        public void AddStat(CharacterStat stat)
        {
            _stats.Add(stat);
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            _stats.Remove(stat);
        }
    }
}