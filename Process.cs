using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public enum ProcessStatus { ready, running, waiting, terminated }

public class Process
{
    public event EventHandler FreeingAResource;
    public long Id { get; private set; }
    public string Name { get; set; }
    public long BurstTime { get; set; }
    public ProcessStatus Status { get; set; }
    public long WorkTime { get; private set; }
    public long AddrSpace { get;  set; }
    private static Random procRand = new Random();
    public int Priority;

public Process(long id, long addrSpace)
{
            this.Id = id;
            if (addrSpace > 0)
                this.AddrSpace = addrSpace;
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
    public void ResetWorkTime()
        {
            WorkTime = 0;
        }

    public override string ToString()
    {
        return "Id: " + this.Id + " Burst time " + this.BurstTime + " Work time " + this.WorkTime + " Status " + this.Status + " Address space " + this.AddrSpace;
    }

    public ProcessStatus randStatus()
    {
        return procRand.Next(2) == 0 ? ProcessStatus.terminated : ProcessStatus.waiting;
    }

    public void OnResourceFreeing()
{
        if (FreeingAResource != null)
            FreeingAResource(this, null);
}

}
