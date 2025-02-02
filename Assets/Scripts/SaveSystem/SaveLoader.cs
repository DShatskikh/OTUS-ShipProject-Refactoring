using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public abstract class SaveLoader<TService, TData> : ISaveLoader
    {
        private TService _service;

        [Inject]
        private void Construct(TService service)
        {
            _service = service;
        }

        void ISaveLoader.Load(IGameRepository gameRepository)
        {
            if (gameRepository.TryGet(typeof(TData).ToString(), out TData data))
            {
                SetupData(_service, data);
                Debug.Log($"{typeof(TData)} loaded");
            }
            else
            {
                SetupDefaultData(_service);
                Debug.Log($"{typeof(TData)} not loaded");
            }
        }

        void ISaveLoader.Save(IGameRepository gameRepository)
        {
            var data = ConvertToData(_service);
            gameRepository.Set(typeof(TData).ToString(), data);
        }

        protected abstract TData ConvertToData(TService service);
        protected abstract void SetupData(TService service, TData data);
        protected virtual void SetupDefaultData(TService service) {}
    }
}