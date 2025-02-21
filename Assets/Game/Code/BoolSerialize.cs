namespace Atomic.Contexts
{
    //Костыль bool не работает в SceneContext
    public class BoolSerialize
    {
        public bool Value;

        public BoolSerialize(bool value)
        {
            Value = value;
        }
    }
}