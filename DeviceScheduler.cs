using System.Collections;

public class DeviceScheduler
{
    private Resource resource;
    public Queue<Process> queue { get; private set; }

    public DeviceScheduler(Resource resource, Queue<Process> Queue)
    { 
        this.resource = resource;
        this.queue = Queue;
    }




    public void Session()
    {
        
           
        
        if (!resource.IsFree())
        {
            var activeProcess = resource.ActiveProcess;
            activeProcess.IncreaseWorkTime();

            if (activeProcess.WorkTime >= activeProcess.BurstTime)
            {
                activeProcess.Status = ProcessStatus.ready;
            }

            if (activeProcess.Status == ProcessStatus.ready)
            {
                Console.WriteLine($"Process {activeProcess.Id} finished on the device.");
                resource.ActiveProcess = null;
            }
        }
        else if (queue.Count != 0)
        {
            var process = queue.Dequeue();
            if (resource.ActiveProcess != process)
            {
                process.Status = ProcessStatus.running;
                process.ResetWorkTime();
                resource.ActiveProcess = process;
                Console.WriteLine($"Process {process.Id} started on the device.");
            }
        }
    }
}
