using lab_gui.model;
using System;
using System.Windows.Forms;


namespace lab_gui
{
    public partial class Form1 : Form
    {
        private Model model = new Model();
        private bool isRunning = false;

        public Form1()
        {

            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
            model.SaveSettings();
            this.Text += " (" + (((double)(formTimer.Interval) / 1000).ToString()) + " с на такт)";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            model.WorkingCycle();

            updateProcessDisplay();
            updateRamSizeLabel();
            updateRamOcupuedSizeLabel();
            updateProgressBar();
        }

        private void updateProcessDisplay()
        {
            cpuQueueTextBox.Clear();
            deviceQueueTextBox.Clear();

            foreach (var item in model.ReadyQueue.UnorderedItems)
            {
                var process = item.Element;

                cpuQueueTextBox.AppendText(process?.ToString() + "\n");
            }

            foreach (var process in model.DeviceQueue)
            {

                deviceQueueTextBox.AppendText(process?.ToString() + "\n");
            }

            string forReplace = $"Priority [{model.device.ActiveProcess?.Priority}] ";
            deviceActiveProcess.Text = model.device.ActiveProcess?.ToString().Replace(forReplace, "");

            cpuActiveProcess.Text = model.cpu.ActiveProcess?.ToString();

            stepLabel.Text = model.clock.Clock.ToString();
        }

        private void start_Click(object sender, EventArgs e)
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

        private void saveSettingsFromNumerics()
        {
            try
            {
                model.initSettings((double)this.intensitynumericUpDown.Value,
                    (int)this.minTimenumericUpDown.Value,
                    (int)this.maxTimenumericUpDown.Value,
                    (int)this.addrMinnumericUpDown.Value,
                    (int)this.addrMaxnumericUpDown.Value,
                    (int)this.ramSizenumericUpDown.Value,
                    (int)this.quantumNumericUpDown.Value);

                setQuantum();

            }
            catch (Exception ex)
            {
                model.ClearResourcesAndQueues();
            }
        }

        private void updateRamSizeLabel()
        {
            realTimeSizeOfRamLabel.Text = (ramSizenumericUpDown.Value).ToString();
        }

        private void updateRamOcupuedSizeLabel()
        {
            ramSizeBusyLabel.Text = model.memoryManager.memory.OccupiedSize.ToString();
        }

        private void minTimenumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void maxTimenumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void addrMinnumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void addrMaxnumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void setQuantum()
        {
            model.cpuScheduler.SetQuantum((int)quantumNumericUpDown.Value);
        }

        private void quantNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (quantumNumericUpDown.Value >= maxTimenumericUpDown.Value)
            {
                quantumNumericUpDown.Value = maxTimenumericUpDown.Value;
            }
        }

        private void updateProgressBar()
        {
            double percentage = (double)model.memoryManager.memory.OccupiedSize / (double)model.modelSettings.ValueOfRAMSize * 100;
            ramProgressBar.Value = (int)percentage;
        }

        private void saveSattingsButton_Click(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
            updateProcessDisplay();
            updateRamSizeLabel();
            updateRamOcupuedSizeLabel();
            updateProgressBar();
        }
    }
}