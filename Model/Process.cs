namespace lab_gui.model
{
    public enum ProcessStatus { ready, running, waiting, terminated }

    public class Process
    {
        public event EventHandler FreeingAResource;
        public long Id { get; private set; }
        public string Name { get; private set; }
        public long BurstTime { get; set; }
        public ProcessStatus Status { get; set; }
        public long WorkTime { get; private set; }
        public long AddrSpace { get; private set; }
        static Random procRand = new Random();
        public int Priority;

        public Process(long id, long addrSpace)
        {
            Id = id;

            if (addrSpace > 0)
                AddrSpace = addrSpace;

            Name = "P" + id;
            Status = ProcessStatus.ready;
        }

        public void IncreaseWorkTime()
        {
            if (WorkTime < BurstTime)
            {
                WorkTime++;
            }
            else
            {
                if (Status == ProcessStatus.waiting)
                    Status = ProcessStatus.ready;
                else
                {
                    Status = randStatus();
                }

                OnResourceFreeing();
            }
        }

        public void ResetWorkTime() => WorkTime = 0;

        public override string ToString()
        {
            return "Id: " + Id + " " +
                   "[" + Status + "]" +
                   " Priority [" + Priority + "]" +
                   " AddrsSpace" + " [" + AddrSpace + "]" +
                   " Work time " + "[" + WorkTime +
                   "/" + BurstTime + "]";
        }

        public ProcessStatus randStatus()
        {
            return procRand.Next(10) < 4 ? ProcessStatus.terminated : ProcessStatus.waiting;
        }

        public void OnResourceFreeing()
        {
            if (FreeingAResource != null)
                FreeingAResource(this, null);
        }
    }
}