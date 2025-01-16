using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;
        
        private CharacterStat _stat;
        private string _name;
        private int _value;

        public void Init(CharacterStat stat)
        {
            _stat = stat;
            _name = stat.Name;
            _value = stat.Value;

            UpgradeValue();
            stat.OnValueChanged += OnValueChanged;
        }

        private void OnDestroy()
        {
            _stat.OnValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            _value = value;
            UpgradeValue();
        }

        private void UpgradeValue() => 
            _label.text = $"{_name}: {_value}";
    }
}