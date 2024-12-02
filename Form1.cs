namespace lab_gui
{
    public partial class GuiForm : Form
    {
        private Model model = new Model();
        private bool isRunning = false; // ��� ������������ ��������� �������

        public GuiForm()
        {

            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
            model.SaveSettings();
            this.Text += " (" + (((double)(timer1.Interval) / 1000).ToString()) + " � �� ����)";
        }

        // ���������� ��� ���������� ������ � ����������
        private void timer1_Tick(object sender, EventArgs e)
        {
            model.WorkingCycle();

            UpdateProcessDisplay();
            updateRamSizeLabel();
            updateRamBusySizeLabel();
            updateProgressBar();
        }

        // ���������� ����������� ���������� � ���������
        private void UpdateProcessDisplay()
        {
            cpuQueueTextBox.Clear(); // ������� ��������� ���� ����� �����������
            deviceQueueTextBox.Clear();
            // ���������� ��� �������� � ������� ReadyQueue
            foreach (var item in model.ReadyQueue.UnorderedItems)
            {
                var process = item.Element;

                // ��������� ���������� � �������� � ��������� ����
                cpuQueueTextBox.AppendText(process?.ToString().Trim() + "\n");
            }
            
                foreach (var process in model?.DeviceQueue)
                {

                    deviceQueueTextBox.AppendText(process?.ToString().Trim() + "\n");
                }
            
            cpuActiveProcess.Text = model.cpu.ActiveProcess?.ToString().Trim();
            deviceActiveProcess.Text = model.device.ActiveProcess?.ToString().Trim();
            stepLabel.Text = model.clock.Clock.ToString();
        }

        // ���������� ��� ������ "Start"
        private void start_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                timer1.Start();
                start.Text = "����";
                isRunning = true;
            }
            else
            {
                timer1.Stop();
                start.Text = "�����";
                isRunning = false;
            }
        }

        private void cpuActiveProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveSattingsButton_Click(object sender, EventArgs e)
        {
            saveSettingsFromNumerics();
        }

        private void saveSettingsFromNumerics()
        {
            model.initSettings((double)this.intensitynumericUpDown.Value,
                (int)this.minTimenumericUpDown.Value,
                (int)this.maxTimenumericUpDown.Value,
                (int)this.addrMinnumericUpDown.Value,
                (int)this.addrMaxnumericUpDown.Value,
                (int)this.ramSizenumericUpDown.Value);
            setQuantum();
        }

        private void updateRamSizeLabel()
        {
            realTimeSizeOfRamLabel.Text = (ramSizenumericUpDown.Value).ToString();
        }

        private void updateRamBusySizeLabel()
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
                if (quantNumericUpDown.Value >= maxTimenumericUpDown.Value)
                {
                    quantNumericUpDown.Value = maxTimenumericUpDown.Value;
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
            model.cpuScheduler.SetQuantum((int)quantNumericUpDown.Value);
        }

        private void quantNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (quantNumericUpDown.Value >= maxTimenumericUpDown.Value)
            {
                quantNumericUpDown.Value = maxTimenumericUpDown.Value;
            }
        }

        private void updateProgressBar()
        {

            // ��������� ������� �������������
            double percentage = (double)model.memoryManager.memory.OccupiedSize / (double)ramSizenumericUpDown.Value * 100;

            // ������������ �������� � �������� �� 0 �� 100
            ramProgressBar.Value = (int)percentage;

            // ���� �������� �����������, �������� ��������


        }

      
    }
}
