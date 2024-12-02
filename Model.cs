using System;
using System.Collections.Generic;

public class Model
{
    public SystemClock clock { get; private set; }
    public Resource cpu { get; private set; }
    public Resource device { get; private set; }
    public Memory ram { get; private set; }
    public IdGenerator idGen { get; private set; }
    public PriorityQueue<Process, long> ReadyQueue { get; set; }
    public Queue<Process> DeviceQueue { get;  set; }
    public CPUScheduler cpuScheduler { get; private set; }
    public MemoryManager memoryManager { get; private set; }
    public DeviceScheduler deviceScheduler { get; private set; }
    public Random processRand { get; private set; }
    public Settings modelSettings { get; private set; }

    private int processMaxPriority = 6;
    private int processMinPriority = 1;


    public Model()
    {
        clock = new SystemClock();
        cpu = new Resource();
        device = new Resource();
        ram = new Memory();
        idGen = new IdGenerator();
        ReadyQueue = new PriorityQueue<Process, long>();
        DeviceQueue = new Queue<Process>();
        cpuScheduler = new CPUScheduler(cpu, ReadyQueue, 4);
        memoryManager = new MemoryManager();
        deviceScheduler = new DeviceScheduler(device, DeviceQueue);
        processRand = new Random();
        modelSettings = new Settings();

       
    }



    public void SaveSettings()
    {
        ram.Save(modelSettings.ValueOfRAMSize);
        memoryManager.Save(ram);
    }

    public void WorkingCycle()
    {
        clock.WorkingCycle();
        cpuScheduler.Execute();
         cpu.WorkingCycle();      
        cpuScheduler.Session();
                
        deviceScheduler.Session(); 

        if (ShouldCreateProcess())
        {
            Process proc = new Process(idGen.Id, processRand.Next(modelSettings.MinValueOfAddrSpace, modelSettings.MaxValueOfAddrSpace + 1))
            {
                BurstTime = processRand.Next(modelSettings.MinValueOfBurstTime, modelSettings.MaxValueOfBurstTime + 1),
                Priority = processRand.Next(processMinPriority, processMaxPriority + 1) 
            };

            if (memoryManager.Allocate(proc))
            {
                ReadyQueue.Enqueue(proc, proc.Priority); 
            }
            Subscribe(proc);
        }

        
        
        
    }






    private bool ShouldCreateProcess()
    {
        return processRand.NextDouble() < modelSettings.Intensity;
    }

    private void CreateProcess()
    {
        var process = new Process(idGen.Id, modelSettings.MinValueOfAddrSpace);
        process.BurstTime = processRand.Next(modelSettings.MinValueOfBurstTime, modelSettings.MaxValueOfBurstTime);

        if (memoryManager.Allocate(process))
        {
            ReadyQueue.Enqueue(process, process.BurstTime);
            Subscribe(process);
        }
    }

    public void Clear()
    {
        cpu.Clear();
        device.Clear();
        ram.Clear();
        ReadyQueue.Clear();
        DeviceQueue.Clear();
        idGen.Clear();
    }

    private void freeingResourceEventHandler(object obj, EventArgs e)
    {
        Process proc = obj as Process;
        if (proc == null)
            return;

        proc.ResetWorkTime();
        Unsubscribe(proc);

        switch (proc.Status)
        {
            case ProcessStatus.ready:
                if (device.ActiveProcess == proc)
                    device.Clear();
                    memoryManager.Free(proc);
                if (cpu.ActiveProcess == proc)
                    memoryManager.Free(proc);


                if (!ReadyQueue.UnorderedItems.Any(p => p.Element == proc))
                {
                    ReadyQueue.Enqueue(proc, proc.Priority);
                    Console.WriteLine($"Process {proc.Id} moved to ReadyQueue.");
                }

                
               Subscribe(proc);
                break;

            case ProcessStatus.waiting:
                if (cpu.ActiveProcess == proc)
                    memoryManager.Free(proc);
                    cpu.Clear();

                if (!DeviceQueue.Contains(proc))
                {
                    DeviceQueue.Enqueue(proc);
                    Console.WriteLine($"Process {proc.Id} moved to DeviceQueue.");
                }
                Subscribe(proc);            
                break;

            case ProcessStatus.terminated:
                if (cpu.ActiveProcess == proc)
                    memoryManager.Free(proc);
                    cpu.Clear();
                break;

            default:
                Console.WriteLine($"Unknown status for process {proc.Id}: {proc.Status}");
                break;
        }
    }








    public void Subscribe(Process proc)
    {
        if (proc != null)
        {
            proc.FreeingAResource += freeingResourceEventHandler;
        }
    }
    public void Unsubscribe(Process proc)
    {
        proc.FreeingAResource -= freeingResourceEventHandler;
    }


    

    public void initSettings(double intensity, int burstMin, int burstMax, int addrSpaceMin, int addrSpaceMax, int ramSize)
    {
        modelSettings.Intensity = intensity;
        modelSettings.MinValueOfBurstTime = burstMin;
        modelSettings.MaxValueOfBurstTime = burstMax;
        modelSettings.MinValueOfAddrSpace = addrSpaceMin;
        modelSettings.MaxValueOfAddrSpace = addrSpaceMax;
        modelSettings.ValueOfRAMSize = ramSize;

        // Инициализация оперативной памяти
        ram.Save(ramSize);

        ReadyQueue.Clear();
        DeviceQueue.Clear();

        // Сброс состояния ресурсов
        cpu.Clear();
        device.Clear();

    }
}
