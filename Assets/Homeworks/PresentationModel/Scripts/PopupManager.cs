using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Lessons.Architecture.PM
{
    public sealed class PopupManager
    {
        private readonly SerializablePair<PopupType, BasePopup>[] _pairs;
        private readonly Transform _container;
        private readonly DiContainer _diContainer;
        private readonly Dictionary<PopupType, BasePopup> _showPopups = new();

        public PopupManager(SerializablePair<PopupType, BasePopup>[] pairs, Transform container, DiContainer diContainer)
        {
            _pairs = pairs;
            _container = container;
            _diContainer = diContainer;
        }

        public void Show(PopupType popupType)
        {
            foreach (var pair in _pairs)
            {
                if (popupType != pair.Key) continue;
                if (_showPopups.ContainsKey(popupType))
                {
                    Debug.Log("The window is already open");
                    return;
                }
                    
                var popup = Object.Instantiate(pair.Value, _container);
                _diContainer.Inject(popup);
                popup.Show();
                _showPopups.Add(popupType, popup);
                return;
            }

            throw new Exception($"The type is missing {popupType}");
        }

        public void Hide(PopupType popupType)
        {
            foreach (var popup in _showPopups)
            {
                if (popupType == popup.Key)
                {
                    Object.Destroy(popup.Value.gameObject);
                    _showPopups.Remove(popup.Key);
                    return;
                }
            }

            Debug.Log($"The type is missing {popupType}");
        }
    }
}