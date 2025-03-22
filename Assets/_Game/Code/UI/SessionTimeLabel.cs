using TMPro;
using UnityEngine;
using VContainer;

namespace Game
{
    public sealed class SessionTimeLabel : MonoBehaviour
    {
        private SessionTimeSystem _sessionTimeSystem;
        private TMP_Text _label;

        [Inject]
        private void Construct(SessionTimeSystem sessionTimeSystem)
        {
            _sessionTimeSystem = sessionTimeSystem;
            _label = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _label.text = _sessionTimeSystem.GetTextTime();
        }
    }
}