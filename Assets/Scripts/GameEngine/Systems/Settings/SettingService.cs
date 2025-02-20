using SaveSystem;
using UniRx;

namespace GameEngine
{
    public sealed class SettingService
    {
        private FloatReactiveProperty _volume = new();
        private readonly SettingsRepository _settingsRepository;
        public IReadOnlyReactiveProperty<float> Volume => _volume;

        public SettingService(SettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
            
            if (settingsRepository.TryGet("Volume", out float volume))
                _volume.Value = volume;
            else
                _volume.Value = 1;
        }

        public void ChangeVolume(float value)
        {
            if (value > 1)
                value = 1;
            
            if (value < 0)
                value = 0;
            
            _volume.Value = value;
            _settingsRepository.Set("Volume", value);
            _settingsRepository.SaveGame();
        }
    }
}