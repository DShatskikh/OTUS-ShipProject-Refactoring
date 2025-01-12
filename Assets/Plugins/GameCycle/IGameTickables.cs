namespace GameCycle
{
    public interface IGameTickableListener : IGameListener
    {
        void Tick(float delta);
    }
        
    public interface IGameFixedUpdateListener : IGameListener
    {
        void FixedTick(float delta);
    }
}