using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class ChestView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _nameLabel;

        [SerializeField]
        private TMP_Text _timerLabel;

        [SerializeField]
        private Button _openButton;

        public Button GetButton => _openButton;
        
        public void SetIcon(Sprite sprite) => 
            _icon.sprite = sprite;
        
        public void SetNameText(string text) => 
            _nameLabel.text = text;
        
        public void SetTimerText(string text) => 
            _timerLabel.text = text;
        
        public void SetInteractableButton(bool value) => 
            _openButton.interactable = value;
    }
}