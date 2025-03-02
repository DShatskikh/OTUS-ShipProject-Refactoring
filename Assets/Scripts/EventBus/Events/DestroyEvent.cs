namespace Game
{
    public struct DestroyEvent : IEvent
    {
        public Unit Unit;

        public DestroyEvent(Unit unit)
        {
            Unit = unit;
        }
    }
}