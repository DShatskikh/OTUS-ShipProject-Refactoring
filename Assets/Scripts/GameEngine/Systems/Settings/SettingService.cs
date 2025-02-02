using UniRx;
using UnityEngine;

namespace GameEngine
{
    public sealed class SettingService
    {
        private FloatReactiveProperty _volume = new();
        public IReadOnlyReactiveProperty<float> Volume => _volume;

        public SettingService()
        {
            _volume.Value = PlayerPrefs.GetFloat("Volume", 1f);
        }

        public void ChangeVolume(float value)
        {
            if (value > 1)
                value = 1;
            
            if (value < 0)
                value = 0;
            
            _volume.Value = value;
            PlayerPrefs.SetFloat("Volume", value);
        }
    }
}