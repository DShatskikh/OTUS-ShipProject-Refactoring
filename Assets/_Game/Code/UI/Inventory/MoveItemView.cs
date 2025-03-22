using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class MoveItemView : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private TMP_Text _label;

        public void SetImage(Sprite sprite) => 
            _image.sprite = sprite;
        
        public void ToggleActive(bool value) => 
            gameObject.SetActive(value);
        
        public void SetPosition(Vector2 position) => 
            transform.position = position;
        
        public void SetTextLabel(string text) => 
            _label.text = text;
        
        public void ToggleLabelActive(bool value) => 
            _label.gameObject.SetActive(value);
    }
}