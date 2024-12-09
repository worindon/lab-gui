namespace lab_gui.model
{
    public class Model
    {
        public SystemClock clock { get; private set; }
        public Resource cpu { get; private set; }
        public Resource device { get; private set; }
        public Memory ram { get; private set; }
        public IdGenerator idGen { get; private set; }
        public PriorityQueue<Process, long> ReadyQueue { get; set; }
        public Queue<Process> DeviceQueue { get; set; }
        public CPUScheduler cpuScheduler { get; private set; }
        public MemoryManager memoryManager { get; private set; }
        public DeviceScheduler deviceScheduler { get; private set; }
        public Random processRand { get; private set; }
        public Settings modelSettings { get; private set; }

        public Model()
        {
            clock = new SystemClock();
            cpu = new Resource();
            device = new Resource();
            ram = new Memory();
            idGen = new IdGenerator();
            ReadyQueue = new PriorityQueue<Process, long>();
            DeviceQueue = new Queue<Process>();
            memoryManager = new MemoryManager();
            deviceScheduler = new DeviceScheduler(device, DeviceQueue);
            processRand = new Random();
            modelSettings = new Settings();
            cpuScheduler = new CPUScheduler(cpu, ReadyQueue, modelSettings.ValueOfQuantum);
        }

        public void SaveSettings()
        {
            ram.Save(modelSettings.ValueOfRAMSize);
            memoryManager.Save(ram);
        }

        public void WorkingCycle()
        {
            clock.WorkingCycle();

            if (ShouldCreateProcess())
            {
                CreateProcess();
            }

            cpu.WorkingCycle();

            cpuScheduler.Execute();
            cpuScheduler.Session();

            deviceScheduler.Session();
        }

        bool ShouldCreateProcess() => processRand.NextDouble() < modelSettings.Intensity;

        void CreateProcess()
        {
            var proc = new Process(idGen.Id, processRand.Next(modelSettings.MinValueOfAddrSpace, modelSettings.MaxValueOfAddrSpace + 1))
            {
                BurstTime = processRand.Next(modelSettings.MinValueOfBurstTime, modelSettings.MaxValueOfBurstTime + 1),
                Priority = processRand.Next(modelSettings.MinValueOfBurstTime, modelSettings.MaxValueOfBurstTime + 1)
            };

            if (memoryManager.Allocate(proc) != null)
            {
                ReadyQueue.Enqueue(proc, proc.Priority);
                Subscribe(proc);
            }
        }

        public void ClearAll()
        {
            cpu.Clear();
            device.Clear();
            ram.Clear();
            ReadyQueue.Clear();
            DeviceQueue.Clear();
            clock.Clear();
            idGen.Clear();
        }

      
        void FreeingResourceEventHandler(object obj, EventArgs e)
        {
            var proc = obj as Process;

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

                    ReadyQueue.Enqueue(proc, proc.Priority);
                    Subscribe(proc);
                    break;

                case ProcessStatus.waiting:
                    if (cpu.ActiveProcess == proc)
                        memoryManager.Free(proc);
                    cpu.Clear();

                    if (!DeviceQueue.Contains(proc))
                    {
                        proc.Status = ProcessStatus.ready;
                        DeviceQueue.Enqueue(proc);
                    }

                    Subscribe(proc);
                    break;

                case ProcessStatus.terminated:
                    if (cpu.ActiveProcess == proc)
                    {
                        memoryManager.Free(proc);
                        cpu.Clear();
                    }

                    if (proc == device.ActiveProcess)
                    {
                        device.Clear();
                    }

                    break;
            }
        }

        public void Subscribe(Process proc)
        {
            if (proc != null)
            {
                proc.FreeingAResource += FreeingResourceEventHandler;
            }
        }

        public void Unsubscribe(Process proc) => proc.FreeingAResource -= FreeingResourceEventHandler;

        public void initSettings(double intensity,
                                 int burstMin,
                                 int burstMax,
                                 int addrSpaceMin,
                                 int addrSpaceMax,
                                 int ramSize,
                                 int quantum)
        {
            modelSettings.Intensity = intensity;
            modelSettings.MinValueOfBurstTime = burstMin;
            modelSettings.MaxValueOfBurstTime = burstMax;
            modelSettings.MinValueOfAddrSpace = addrSpaceMin;
            modelSettings.MaxValueOfAddrSpace = addrSpaceMax;
            modelSettings.ValueOfRAMSize = ramSize;
            modelSettings.ValueOfQuantum = quantum;
            SaveSettings();
            ClearAll();
        }
    }
}