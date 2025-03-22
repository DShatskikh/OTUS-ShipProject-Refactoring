using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class PastSessionsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;

        public void SetText(string text) => 
            _label.text = text;
    }
}