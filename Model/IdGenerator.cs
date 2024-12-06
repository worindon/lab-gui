namespace lab_gui.model
{
    public class IdGenerator
    {
        private long id;

        public long Id
        {
            get
            {
                return id == long.MaxValue ? 0 : ++id;
            }
        }

        public void Clear()
        {
            id = 0;
        }
    }
}


