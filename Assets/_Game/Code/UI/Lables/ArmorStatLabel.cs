using Game.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class ArmorStatLabel : MonoBehaviour
    {
        private TMP_Text _label;
        
        [Inject]
        private void Construct(ArmorSystem armorSystem)
        {
            _label = GetComponent<TMP_Text>();
            
            OnArmorChange(armorSystem.Armor);
            armorSystem.OnChange += OnArmorChange;
        }

        private void OnArmorChange(int value) => 
            _label.text = $"Защита: {value}";
    }
}