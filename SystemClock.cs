public class SystemClock
{
    private long clock;


    public long Clock
    {
        get => clock;
        private set => clock = value;
    }

    public void WorkingCycle()
    {
        Clock++;
    }

    public void Clear()
    {
        Clock = 0;
    }
}
