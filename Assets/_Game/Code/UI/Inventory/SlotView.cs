using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField]
        private EventTrigger _triggerEvent;

        [SerializeField]
        private Image _frame;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _countLabel;

        [SerializeField]
        private Sprite _deselect;

        [SerializeField]
        private Sprite _select;
        
        public EventTrigger GetTriggerEvent => _triggerEvent;
        
        public void ToggleSelect(bool value) => 
            _frame.sprite = value ? _select : _deselect;

        public void ToggleIcon(bool value) => 
            _icon.gameObject.SetActive(value);

        public void SetIcon(Sprite value) =>
            _icon.sprite = value;

        public void ToggleCountLabel(bool value) => 
            _countLabel.gameObject.SetActive(value);
        
        public void SetTextCountLabel(string value) =>
            _countLabel.text = value;
    }
}