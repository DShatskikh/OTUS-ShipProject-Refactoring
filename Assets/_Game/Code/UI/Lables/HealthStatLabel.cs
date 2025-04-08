using Game.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class HealthStatLabel : MonoBehaviour
    {
        private TMP_Text _label;
        
        [Inject]
        private void Construct(HealthSystem healthSystem)
        {
            _label = GetComponent<TMP_Text>();
            
            OnHealthChange(healthSystem.Health);
            healthSystem.OnChange += OnHealthChange;
        }

        private void OnHealthChange(int value) => 
            _label.text = $"Здоровье: {value}";
    }
}