using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopupHelper : MonoBehaviour
    {
        [ShowInInspector]
        private UserInfo _userInfo;

        [ShowInInspector]
        private CharacterInfo _characterInfo;

        [ShowInInspector]
        private PlayerLevel _playerLevel;

        private PopupManager _popupManager;

        [Inject]
        private void Construct(PopupManager popupManager, UserInfo userInfo,
            CharacterInfo characterInfo, PlayerLevel playerLevel)
        {
            _popupManager = popupManager;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;
        }
        
        private void Start()
        {
            Show();
        }
        
        [Button]
        private void Show()
        {
            _popupManager.Show(PopupType.PlayerPopup);
        }

        [Button]
        private void Hide()
        {
            _popupManager.Hide(PopupType.PlayerPopup);
        }
    }
}