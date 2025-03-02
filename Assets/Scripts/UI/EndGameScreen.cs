using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGameScreen : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;

        public void ToggleShow(bool value) => 
            gameObject.SetActive(value);

        public void SetLabelText(string text) => 
            _label.text = text;
    }
}