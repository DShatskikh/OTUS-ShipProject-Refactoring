using TMPro;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;

        public void Init(CharacterStat stat)
        {
            stat.Value.Subscribe(value =>
            {
                _label.text = $"{stat.Name}: {value}";
            }).AddTo(this);
        }
            
    }
}