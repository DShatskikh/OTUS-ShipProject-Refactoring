using Game.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class AttackStatLabel : MonoBehaviour
    {
        private TMP_Text _label;
        
        [Inject]
        private void Construct(AttackSystem attackSystem)
        {
            _label = GetComponent<TMP_Text>();
            
            attackSystem.OnChange += OnAttackChange;
            OnAttackChange(attackSystem.Attack);
        }
        
        private void OnAttackChange(int value)
        {
            _label.text = $"Атака: {value}";
        }
    }
}