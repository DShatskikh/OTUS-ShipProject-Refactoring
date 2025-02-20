using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public sealed class SettingsRepository : IGameRepository
    {
        private const string GAME_STATE_KEY = "SETTINGS_STATE_KEY";
        private Dictionary<string, byte[]> _gameState = new();

        public SettingsRepository()
        {
            LoadGame();
        }
        
        public void Set<T>(string key, T data)
        {
            _gameState[key] = ES3.Serialize(data);
        }

        public bool TryGet<T>(string key, out T data)
        {
            data = default;

            if (_gameState.TryGetValue(key, out byte[] value))
            {
                data = ES3.Deserialize<T>(value);
                return true;
            }

            return false;
        }

        public void LoadGame()
        {
            if (ES3.KeyExists(GAME_STATE_KEY))
            {
                _gameState = ES3.Load<Dictionary<string, byte[]>>(GAME_STATE_KEY);
                Debug.Log($"LoadGame {_gameState}");
            }
            else
            {
                Debug.Log("LoadGame Not Save");
            }
        }

        public void SaveGame()
        {
            ES3.Save(GAME_STATE_KEY, _gameState);
            Debug.Log($"SaveGame {_gameState}");
        }
    }
}