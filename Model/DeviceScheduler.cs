namespace lab_gui.model
{
    public class DeviceScheduler
    {
        private Resource resource;
        public Queue<Process> queue { get; private set; }

        public DeviceScheduler(Resource resource, Queue<Process> Queue)
        {
            this.resource = resource;
            queue = Queue;
        }

        public void Session()
        {
            if (!resource.IsFree())
            {

                if (resource.ActiveProcess?.BurstTime > resource.ActiveProcess?.WorkTime)
                {
                    resource.ActiveProcess?.IncreaseWorkTime();
                }
                else
                {

                    resource.ActiveProcess.Status = ProcessStatus.terminated;
                    resource.ActiveProcess.OnResourceFreeing();
                }

            }

            if (queue.Count != 0 && resource.IsFree())
            {
                var process = queue.Dequeue();
                if (resource.ActiveProcess != process)
                {
                    process.Status = ProcessStatus.running;
                    process.ResetWorkTime();
                    resource.ActiveProcess = process;
                }
            }
        }
    }
}
