namespace lab_gui
{
    public class Resource
    {
        private Process activeProcess = null;

        public Process ActiveProcess
        {
            get => activeProcess;
            set => activeProcess = value;
        }

        public void WorkingCycle()
        {
            activeProcess?.IncreaseWorkTime();
        }

        public bool IsFree() => activeProcess == null;

        public void Clear()
        {
            activeProcess = null;
        }

        public override string ToString()
        {
            return activeProcess.ToString();
        }
    }
}

