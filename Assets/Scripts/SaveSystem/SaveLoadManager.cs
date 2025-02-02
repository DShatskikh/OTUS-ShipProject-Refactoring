namespace SaveSystem
{
    public sealed class SaveLoadManager
    {
        private readonly ISaveLoader[] _saveLoaders;
        private readonly IGameRepository _gameRepository;

        public SaveLoadManager(ISaveLoader[] saveLoaders, IGameRepository gameRepository)
        {
            _saveLoaders = saveLoaders;
            _gameRepository = gameRepository;
        }
        
        public void Save()
        {
            foreach (var saveLoader in _saveLoaders) 
                saveLoader.Save(_gameRepository);

            _gameRepository.SaveGame();
        }

        public void Load()
        {
            _gameRepository.LoadGame();
            
            foreach (var saveLoader in _saveLoaders) 
                saveLoader.Load(_gameRepository);
        }
    }
}