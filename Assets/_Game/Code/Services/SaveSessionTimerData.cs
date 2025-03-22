using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Game
{
    public sealed class SaveSessionTimerData : MonoBehaviour
    {
        private SessionTimeSystem _sessionTimeSystem;
        private IEnumerable<ChestPresenter> _chestPresenters;

        [Inject]
        private void Construct(SessionTimeSystem sessionTimeSystem, IEnumerable<ChestPresenter> chestPresenters)
        {
            _sessionTimeSystem = sessionTimeSystem;
            _chestPresenters = chestPresenters;
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                _sessionTimeSystem.Save();
                
                foreach (var chestPresenter in _chestPresenters) 
                    chestPresenter.Save();
            }
        }
    }
}