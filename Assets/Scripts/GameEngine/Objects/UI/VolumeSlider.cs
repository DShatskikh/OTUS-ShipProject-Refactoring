using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameEngine
{
    public sealed class VolumeSlider : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;
        
        private Slider _slider;
        private SettingService _settingService;

        [Inject]
        private void Construct(SettingService settingService)
        {
            _settingService = settingService;
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _settingService.Volume.Subscribe(value =>
            {
                _slider.value = value;
                _label.text = $"{Math.Round(value * 100)}%";
            }).AddTo(this);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveAllListeners();
        }

        private void OnSliderValueChanged(float value)
        {
            _settingService.ChangeVolume(value);
        }
    }
}