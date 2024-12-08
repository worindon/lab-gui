namespace lab_gui.model
{
    public class IdGenerator
    {
        long id;

        public long Id => id == long.MaxValue ? 0 : ++id;

        public void Clear() => id = 0;
    }
}


