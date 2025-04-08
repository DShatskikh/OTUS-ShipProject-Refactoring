using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class InfoView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _nameLabel;
        
        [SerializeField]
        private TMP_Text _descriptionLabel;

        public void ToggleActivate(bool value) => 
            gameObject.SetActive(value);

        public void SetNameLabel(string value) => 
            _nameLabel.text = value;
        
        public void SetDescriptionLabel(string value) => 
            _descriptionLabel.text = value;
        
        public void Move(Vector2 value) => 
            transform.position = value;
    }
}