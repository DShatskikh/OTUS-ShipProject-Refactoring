using System;
using Game.Localization;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public sealed class SawmillUpgradeMetadata
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _icon;

        [TranslationKey]
        [SerializeField]
        private string _localizedTitle;
        
        public string GetName => _name;
        public Sprite GetIcon => _icon;
        public string GetLocalizedTitle => _localizedTitle;
    }
}