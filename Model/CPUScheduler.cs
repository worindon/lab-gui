namespace lab_gui.model
{
    public class CPUScheduler
    {
        private Resource resource;
        private PriorityQueue<Process, long> queue;
        private int quantum;
        private int quantumCounter;

        public void SetQuantum(int quantum)
        {
            if (quantum > 0)
            {
                this.quantum = quantum;
            }
        }

        public CPUScheduler(Resource resource, PriorityQueue<Process, long> queue, int quantum)
        {
            this.resource = resource;
            this.queue = queue;
            this.quantum = quantum;
            quantumCounter = 0;
        }

        public void Session()
        {
            if (resource.IsFree() && queue.Count > 0)
            {
                var process = queue.Dequeue();
                process.Status = ProcessStatus.running;
                resource.ActiveProcess = process;
                quantumCounter = 0;
            }

        }

        public void Execute()
        {
            if (resource.ActiveProcess != null)
            {

                var process = resource.ActiveProcess;

                if (++quantumCounter >= quantum)
                {
                    quantumCounter = 0;

                    if (process.WorkTime < process.BurstTime)
                    {
                        process.Status = ProcessStatus.ready;
                        queue.Enqueue(process, process.Priority);

                    }
                    else
                    {
                        process.Status = process.randStatus();
                        process.OnResourceFreeing();

                    }

                    resource.Clear();
                }
            }
        }
    }
}