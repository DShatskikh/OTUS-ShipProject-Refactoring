namespace SaveSystem
{
    public interface IGameRepository
    {
        public void Set<T>(string key, T data);
        public bool TryGet<T>(string key, out T data);
        public void SaveGame();
        public void LoadGame();
    }
}