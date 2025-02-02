namespace SaveSystem
{
    public interface ISaveLoader
    {
        void Save(IGameRepository gameRepository);
        void Load(IGameRepository gameRepository);
    }
}