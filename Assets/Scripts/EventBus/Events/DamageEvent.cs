namespace Game
{
    public struct DamageEvent : IEvent
    {
        public Unit Unit;
        public int Damage;

        public DamageEvent(Unit unit, int damage)
        {
            Unit = unit;
            Damage = damage;
        }
    }
}