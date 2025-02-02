using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public sealed class SaveLoadTest : MonoBehaviour
    {
        private SaveLoadManager _saveLoadManager;

        [Inject]
        private void Construct(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }

        [Button]
        private void Save()
        {
            _saveLoadManager.Save();
        }

        [Button]
        private void Load()
        {
            _saveLoadManager.Load();
        }
    }
}