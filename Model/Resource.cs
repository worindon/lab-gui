namespace lab_gui.model
{
    public class Resource
    {
        Process activeProcess;

        public Process ActiveProcess
        {
            get => activeProcess;
            set => activeProcess = value;
        }

        public void WorkingCycle() => activeProcess?.IncreaseWorkTime();

        public bool IsFree() => activeProcess == null;

        public void Clear() => activeProcess = null;

        public override string ToString() => activeProcess.ToString();
    }
}

