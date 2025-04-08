using Game.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class SpeedStatLabel : MonoBehaviour
    {
        private TMP_Text _label;
        
        [Inject]
        private void Construct(SpeedSystem speedSystem)
        {
            _label = GetComponent<TMP_Text>();
            
            OnSpeedChange(speedSystem.Speed);
            speedSystem.OnChange += OnSpeedChange;
        }

        private void OnSpeedChange(int value) => 
            _label.text = $"Скорость: {value}";
    }
}