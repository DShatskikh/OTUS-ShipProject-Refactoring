using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat
    {
        [ShowInInspector]
        private readonly ReactiveProperty<int> _value = new();
        
        public ReactiveProperty<int> Value => _value;
        
        [ShowInInspector, ReadOnly]
        public string Name { get; private set; }

        public CharacterStat(string name, int value)
        {
            Name = name;
            _value.Value = value;
        }
        
        [Button]
        public void ChangeValue(int value)
        {
            _value.Value = value;
        }
    }
}