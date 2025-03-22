using System;
using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class ChestPresenter : ITickable
    {
        private readonly ChestView _view;
        private readonly ChestConfig _config;
        
        private DateTime _endGameTime;
        private string _key => $"Chest_{_config.GetID}";

        public ChestPresenter(ChestView view, ChestConfig config)
        {
            _view = view;
            _config = config;
            
            _view.SetIcon(config.GetIcon);
            _view.SetNameText(config.GetName);
            _view.GetButton.onClick.AddListener(OnClick);
            
            Load();
        }

        public void Tick()
        {
            if (_endGameTime <= DateTime.Now)
            {
                _view.SetInteractableButton(true);
                _view.SetTimerText("");
            }
            else
            {
                _view.SetInteractableButton(false);
                _view.SetTimerText(SessionTimeSystem.GetTextTime(_endGameTime - DateTime.Now));
            }
        }

        public void Save()
        {
            var saveString = _endGameTime.ToString("yyyy-MM-dd HH:mm:ss");
            PlayerPrefs.SetString(_key, saveString);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey(_key))
            {
                var loadString = PlayerPrefs.GetString(_key);
                _endGameTime = DateTime.ParseExact(loadString, "yyyy-MM-dd HH:mm:ss", null);
            }
            else
            {
                _endGameTime = DateTime.Now;
            }
        }

        private void OnClick()
        {
            _endGameTime = DateTime.Now;
            _endGameTime = _endGameTime.AddSeconds(_config.GetTimeSecond);
            _config.GetOpenAction.Open();
        }
    }
}