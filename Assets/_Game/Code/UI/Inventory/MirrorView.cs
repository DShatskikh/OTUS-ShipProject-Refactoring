using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class MirrorView : MonoBehaviour
    {
        [SerializeField]
        private Image _helmet;

        [SerializeField]
        private Image _chestplate;
        
        [SerializeField]
        private Image _leggings;
        
        [SerializeField]
        private Image _boots;

        public void ToggleHelmet(bool value) => 
            _helmet.gameObject.SetActive(value);

        public void SetHelmet(Sprite value) => 
            _helmet.sprite = value;
        
        public void ToggleChestplate(bool value) => 
            _chestplate.gameObject.SetActive(value);

        public void SetChestplate(Sprite value) => 
            _chestplate.sprite = value;
        
        public void ToggleLeggings(bool value) => 
            _leggings.gameObject.SetActive(value);

        public void SetLeggings(Sprite value) => 
            _leggings.sprite = value;
        
        public void ToggleBoots(bool value) => 
            _boots.gameObject.SetActive(value);

        public void SetBoots(Sprite value) => 
            _boots.sprite = value;
    }
}