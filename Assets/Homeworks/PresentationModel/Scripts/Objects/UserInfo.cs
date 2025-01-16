using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfo
    {
        [ShowInInspector]
        private ReactiveProperty<Sprite> _icon = new();
        
        [ShowInInspector]
        private ReactiveProperty<string> _name = new();
        
        [ShowInInspector]
        private ReactiveProperty<string> _description = new();
        
        public IReadOnlyReactiveProperty<Sprite> Icon => _icon;
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<string> Description => _description;

        public UserInfo(string name, string description, Sprite icon)
        {
            _name.Value = name;
            _description.Value = description;
            _icon.Value = icon;
        }

        [Button]
        public void ChangeName(string name)
        {
            _name.Value = name;
        }

        [Button]
        public void ChangeDescription(string description)
        {
            _description.Value = description;
        }

        [Button]
        public void ChangeIcon(Sprite icon)
        {
            _icon.Value = icon;
        }
    }
}