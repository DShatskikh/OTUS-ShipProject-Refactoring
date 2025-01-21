using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat : IDisposable
    {
        [ShowInInspector]
        private readonly ReactiveProperty<int> _value = new();
        
        [ShowInInspector]
        private readonly ReactiveProperty<string> _displayStat = new();
        
        public IReadOnlyReactiveProperty<string> DisplayStat => _displayStat;
        
        [ShowInInspector, ReadOnly]
        public string Name { get; private set; }

        public CharacterStat(string name, int value)
        {
            Name = name;
            _value.Value = value;
            _value.Subscribe(_ => _displayStat.Value = $"{Name}: {_}");
        }
        
        [Button]
        public void ChangeValue(int value)
        {
            _value.Value = value;
        }

        public void Dispose()
        {
            _value?.Dispose();
            _displayStat?.Dispose();
        }
    }
}