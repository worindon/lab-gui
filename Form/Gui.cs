using lab_gui.model;
using System;
using System.Windows.Forms;

namespace lab_gui
{
    public partial class Gui : Form
    {
        Model model = new Model();
        bool isRunning;

        public Gui() => InitializeComponent();

        void Form1_Load(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
            model.SaveSettings();
            Text += " (" + (((double)(formTimer.Interval) / 1000).ToString()) + " с на такт)";
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            model.WorkingCycle();

            updateProcessDisplay();
            updateRamSizeLabel();
            updateRamOcupuedSizeLabel();
            updateProgressBar();
        }

        void updateProcessDisplay()
        {
            cpuQueueTextBox.Clear();
            deviceQueueTextBox.Clear();

            foreach (var item in model.ReadyQueue.UnorderedItems)
            {
                var process = item.Element;

                cpuQueueTextBox.AppendText(process?.ToString() + "\n");
            }

            foreach (var process in model.DeviceQueue)

                deviceQueueTextBox.AppendText(process?.ToString() + "\n");

            var forReplace = $"Priority [{model.device.ActiveProcess?.Priority}] ";
            deviceActiveProcess.Text = model.device.ActiveProcess?.ToString().Replace(forReplace, "");

            cpuActiveProcess.Text = model.cpu.ActiveProcess?.ToString();

            stepLabel.Text = model.clock.Clock.ToString();
        }

        void start_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                formTimer.Start();
                start.Text = "Стоп";
                isRunning = true;
            }
            else
            {
                formTimer.Stop();
                start.Text = "Старт";
                isRunning = false;
            }
        }

        void saveSettingsFromNumerics()
        {
            model.initSettings((double)intensitynumericUpDown.Value,
                (int)minTimenumericUpDown.Value,
                (int)maxTimenumericUpDown.Value,
                (int)addrMinnumericUpDown.Value,
                (int)addrMaxnumericUpDown.Value,
                (int)ramSizenumericUpDown.Value,
                (int)quantumNumericUpDown.Value);

            setQuantum();
        }

        void updateRamSizeLabel()
        {
            realTimeSizeOfRamLabel.Text = (ramSizenumericUpDown.Value).ToString();
        }

        void updateRamOcupuedSizeLabel()
        {
            ramSizeBusyLabel.Text = model.memoryManager.memory.OccupiedSize.ToString();
        }

        void minTimenumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (minTimenumericUpDown.Value >= maxTimenumericUpDown.Value)
                {
                    ++maxTimenumericUpDown.Value;
                }
            }
            catch { }
        }

        void maxTimenumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (maxTimenumericUpDown.Value <= minTimenumericUpDown.Value)
                {
                    --minTimenumericUpDown.Value;
                }

                if (quantumNumericUpDown.Value >= maxTimenumericUpDown.Value)
                {
                    quantumNumericUpDown.Value = maxTimenumericUpDown.Value;
                }
            }
            catch { }
        }

        void addrMinnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (addrMinnumericUpDown.Value >= addrMaxnumericUpDown.Value)
                {
                    ++addrMaxnumericUpDown.Value;
                }
            }
            catch { }
        }

        void addrMaxnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (addrMaxnumericUpDown.Value <= addrMinnumericUpDown.Value)
                {
                    --addrMinnumericUpDown.Value;
                }
            }
            catch { }
        }

        void setQuantum() => model.cpuScheduler.SetQuantum((int)quantumNumericUpDown.Value);

        void quantNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (quantumNumericUpDown.Value >= maxTimenumericUpDown.Value)
            {
                quantumNumericUpDown.Value = maxTimenumericUpDown.Value;
            }

            setQuantum();
        }

        void updateProgressBar()
        {
            var percentage = (double)model.memoryManager.memory.OccupiedSize / (double)model.modelSettings.ValueOfRAMSize * 100;
            ramProgressBar.Value = (int)percentage;
        }

        void saveSattingsButton_Click(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
            updateProcessDisplay();
            updateRamSizeLabel();
            updateRamOcupuedSizeLabel();
            updateProgressBar();
        }
    }
}