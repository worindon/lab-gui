using System.Drawing;
using System.Windows.Forms;

namespace lab_gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            formTimer = new System.Windows.Forms.Timer(components);
            cpuQueueTextBox = new RichTextBox();
            start = new Button();
            stepLabel = new Label();
            cpuTextBoxLabelConst = new Label();
            deviceQueueTextBox = new RichTextBox();
            deviceTextBoxLabelConst = new Label();
            cpuActiveProcess = new TextBox();
            deviceActiveProcess = new TextBox();
            nextStepButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            intensitynumericUpDown = new NumericUpDown();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            minTimenumericUpDown = new NumericUpDown();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            maxTimenumericUpDown = new NumericUpDown();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label4 = new Label();
            ramSizenumericUpDown = new NumericUpDown();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label5 = new Label();
            addrMinnumericUpDown = new NumericUpDown();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label6 = new Label();
            addrMaxnumericUpDown = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            saveSattingsButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            realTimeSizeOfRamLabel = new Label();
            ramInfoLabel = new Label();
            ramSizeBusyInfoLabel = new Label();
            ramSizeBusyLabel = new Label();
            quantLabel = new Label();
            quantumNumericUpDown = new NumericUpDown();
            ramProgressBar = new ProgressBar();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)intensitynumericUpDown).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minTimenumericUpDown).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maxTimenumericUpDown).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ramSizenumericUpDown).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addrMinnumericUpDown).BeginInit();
            flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addrMaxnumericUpDown).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantumNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // formTimer
            // 
            formTimer.Interval = 1;
            formTimer.Tick += timer1_Tick;
            // 
            // cpuQueueTextBox
            // 
            cpuQueueTextBox.BackColor = SystemColors.ControlLight;
            cpuQueueTextBox.ForeColor = SystemColors.Desktop;
            cpuQueueTextBox.Location = new Point(3, 150);
            cpuQueueTextBox.Name = "cpuQueueTextBox";
            cpuQueueTextBox.ReadOnly = true;
            cpuQueueTextBox.Size = new Size(447, 144);
            cpuQueueTextBox.TabIndex = 0;
            cpuQueueTextBox.Text = "";
            // 
            // start
            // 
            start.Location = new Point(624, 483);
            start.Name = "start";
            start.Size = new Size(94, 49);
            start.TabIndex = 2;
            start.Text = "Старт";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // stepLabel
            // 
            stepLabel.Anchor = AnchorStyles.None;
            stepLabel.AutoSize = true;
            stepLabel.Font = new Font("Segoe UI", 18F);
            stepLabel.Location = new Point(3, 1);
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(34, 41);
            stepLabel.TabIndex = 4;
            stepLabel.Text = "0";
            stepLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpuTextBoxLabelConst
            // 
            cpuTextBoxLabelConst.AutoSize = true;
            cpuTextBoxLabelConst.Location = new Point(103, 112);
            cpuTextBoxLabelConst.Name = "cpuTextBoxLabelConst";
            cpuTextBoxLabelConst.Size = new Size(253, 20);
            cpuTextBoxLabelConst.TabIndex = 5;
            cpuTextBoxLabelConst.Text = "Черга до центрального прочесора";
            // 
            // deviceQueueTextBox
            // 
            deviceQueueTextBox.BackColor = SystemColors.ControlLight;
            deviceQueueTextBox.ForeColor = SystemColors.Desktop;
            deviceQueueTextBox.Location = new Point(459, 150);
            deviceQueueTextBox.Name = "deviceQueueTextBox";
            deviceQueueTextBox.ReadOnly = true;
            deviceQueueTextBox.Size = new Size(447, 144);
            deviceQueueTextBox.TabIndex = 6;
            deviceQueueTextBox.Text = "";
            // 
            // deviceTextBoxLabelConst
            // 
            deviceTextBoxLabelConst.AutoSize = true;
            deviceTextBoxLabelConst.Location = new Point(565, 112);
            deviceTextBoxLabelConst.Name = "deviceTextBoxLabelConst";
            deviceTextBoxLabelConst.Size = new Size(239, 20);
            deviceTextBoxLabelConst.TabIndex = 7;
            deviceTextBoxLabelConst.Text = "Черга до зовнішнього пристрою";
            // 
            // cpuActiveProcess
            // 
            cpuActiveProcess.ImeMode = ImeMode.NoControl;
            cpuActiveProcess.Location = new Point(3, 34);
            cpuActiveProcess.Multiline = true;
            cpuActiveProcess.Name = "cpuActiveProcess";
            cpuActiveProcess.ReadOnly = true;
            cpuActiveProcess.ShortcutsEnabled = false;
            cpuActiveProcess.Size = new Size(447, 52);
            cpuActiveProcess.TabIndex = 8;
            // 
            // deviceActiveProcess
            // 
            deviceActiveProcess.Location = new Point(459, 34);
            deviceActiveProcess.Multiline = true;
            deviceActiveProcess.Name = "deviceActiveProcess";
            deviceActiveProcess.ReadOnly = true;
            deviceActiveProcess.ShortcutsEnabled = false;
            deviceActiveProcess.Size = new Size(447, 52);
            deviceActiveProcess.TabIndex = 9;
            // 
            // nextStepButton
            // 
            nextStepButton.Location = new Point(724, 483);
            nextStepButton.Name = "nextStepButton";
            nextStepButton.Size = new Size(94, 49);
            nextStepButton.TabIndex = 10;
            nextStepButton.Text = "Наступний крок";
            nextStepButton.UseVisualStyleBackColor = true;
            nextStepButton.Click += timer1_Tick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(intensitynumericUpDown);
            flowLayoutPanel1.Location = new Point(12, 10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(136, 93);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 60);
            label1.TabIndex = 13;
            label1.Text = "Інтенсивність надходження процесів";
            // 
            // intensitynumericUpDown
            // 
            intensitynumericUpDown.DecimalPlaces = 1;
            intensitynumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            intensitynumericUpDown.Location = new Point(3, 63);
            intensitynumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            intensitynumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            intensitynumericUpDown.Name = "intensitynumericUpDown";
            intensitynumericUpDown.Size = new Size(136, 27);
            intensitynumericUpDown.TabIndex = 19;
            intensitynumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(minTimenumericUpDown);
            flowLayoutPanel2.Location = new Point(154, 10);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(136, 93);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 60);
            label2.TabIndex = 14;
            label2.Text = "Мінімальний проміжок роботи на ЦП";
            // 
            // minTimenumericUpDown
            // 
            minTimenumericUpDown.Location = new Point(3, 63);
            minTimenumericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            minTimenumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            minTimenumericUpDown.Name = "minTimenumericUpDown";
            minTimenumericUpDown.Size = new Size(133, 27);
            minTimenumericUpDown.TabIndex = 20;
            minTimenumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            minTimenumericUpDown.ValueChanged += minTimenumericUpDown_ValueChanged;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(maxTimenumericUpDown);
            flowLayoutPanel3.Location = new Point(296, 10);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(136, 93);
            flowLayoutPanel3.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(119, 60);
            label3.TabIndex = 15;
            label3.Text = "Максимальний проміжок роботи на ЦП";
            // 
            // maxTimenumericUpDown
            // 
            maxTimenumericUpDown.Location = new Point(3, 63);
            maxTimenumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            maxTimenumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            maxTimenumericUpDown.Name = "maxTimenumericUpDown";
            maxTimenumericUpDown.Size = new Size(133, 27);
            maxTimenumericUpDown.TabIndex = 21;
            maxTimenumericUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            maxTimenumericUpDown.ValueChanged += maxTimenumericUpDown_ValueChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label4);
            flowLayoutPanel4.Controls.Add(ramSizenumericUpDown);
            flowLayoutPanel4.Location = new Point(438, 10);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(136, 93);
            flowLayoutPanel4.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 60);
            label4.TabIndex = 16;
            label4.Text = "Розмір оперативної пам'яті";
            // 
            // ramSizenumericUpDown
            // 
            ramSizenumericUpDown.Increment = new decimal(new int[] { 128, 0, 0, 0 });
            ramSizenumericUpDown.Location = new Point(3, 63);
            ramSizenumericUpDown.Maximum = new decimal(new int[] { 524288, 0, 0, 0 });
            ramSizenumericUpDown.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            ramSizenumericUpDown.Name = "ramSizenumericUpDown";
            ramSizenumericUpDown.Size = new Size(133, 27);
            ramSizenumericUpDown.TabIndex = 22;
            ramSizenumericUpDown.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label5);
            flowLayoutPanel5.Controls.Add(addrMinnumericUpDown);
            flowLayoutPanel5.Location = new Point(580, 9);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(162, 93);
            flowLayoutPanel5.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(155, 60);
            label5.TabIndex = 17;
            label5.Text = "Мінімальний розмір адресного простору процесу";
            // 
            // addrMinnumericUpDown
            // 
            addrMinnumericUpDown.Increment = new decimal(new int[] { 32, 0, 0, 0 });
            addrMinnumericUpDown.Location = new Point(3, 63);
            addrMinnumericUpDown.Maximum = new decimal(new int[] { 32000, 0, 0, 0 });
            addrMinnumericUpDown.Minimum = new decimal(new int[] { 128, 0, 0, 0 });
            addrMinnumericUpDown.Name = "addrMinnumericUpDown";
            addrMinnumericUpDown.Size = new Size(155, 27);
            addrMinnumericUpDown.TabIndex = 23;
            addrMinnumericUpDown.Value = new decimal(new int[] { 128, 0, 0, 0 });
            addrMinnumericUpDown.ValueChanged += addrMinnumericUpDown_ValueChanged;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(label6);
            flowLayoutPanel6.Controls.Add(addrMaxnumericUpDown);
            flowLayoutPanel6.Location = new Point(748, 9);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(176, 93);
            flowLayoutPanel6.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(168, 60);
            label6.TabIndex = 18;
            label6.Text = "Максимальний розмір адресного простору процесу";
            // 
            // addrMaxnumericUpDown
            // 
            addrMaxnumericUpDown.Increment = new decimal(new int[] { 32, 0, 0, 0 });
            addrMaxnumericUpDown.Location = new Point(3, 63);
            addrMaxnumericUpDown.Maximum = new decimal(new int[] { 64000, 0, 0, 0 });
            addrMaxnumericUpDown.Minimum = new decimal(new int[] { 512, 0, 0, 0 });
            addrMaxnumericUpDown.Name = "addrMaxnumericUpDown";
            addrMaxnumericUpDown.Size = new Size(168, 27);
            addrMaxnumericUpDown.TabIndex = 24;
            addrMaxnumericUpDown.Value = new decimal(new int[] { 512, 0, 0, 0 });
            addrMaxnumericUpDown.ValueChanged += addrMaxnumericUpDown_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(139, 0);
            label7.Name = "label7";
            label7.Size = new Size(176, 20);
            label7.TabIndex = 13;
            label7.Text = "Центральний процесор";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(604, 0);
            label8.Name = "label8";
            label8.Size = new Size(147, 20);
            label8.TabIndex = 14;
            label8.Text = "Зовнішній пристрій";
            // 
            // saveSattingsButton
            // 
            saveSattingsButton.Location = new Point(824, 483);
            saveSattingsButton.Name = "saveSattingsButton";
            saveSattingsButton.Size = new Size(94, 49);
            saveSattingsButton.TabIndex = 24;
            saveSattingsButton.Text = "Зберегти";
            saveSattingsButton.UseVisualStyleBackColor = true;
            saveSattingsButton.Click += saveSattingsButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(deviceQueueTextBox);
            panel1.Controls.Add(cpuQueueTextBox);
            panel1.Controls.Add(deviceTextBoxLabelConst);
            panel1.Controls.Add(cpuTextBoxLabelConst);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(deviceActiveProcess);
            panel1.Controls.Add(cpuActiveProcess);
            panel1.Location = new Point(15, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(909, 316);
            panel1.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.Controls.Add(stepLabel);
            panel2.Location = new Point(515, 483);
            panel2.Name = "panel2";
            panel2.Size = new Size(103, 49);
            panel2.TabIndex = 15;
            // 
            // realTimeSizeOfRamLabel
            // 
            realTimeSizeOfRamLabel.AutoSize = true;
            realTimeSizeOfRamLabel.Location = new Point(252, 497);
            realTimeSizeOfRamLabel.Name = "realTimeSizeOfRamLabel";
            realTimeSizeOfRamLabel.Size = new Size(41, 20);
            realTimeSizeOfRamLabel.TabIndex = 1;
            realTimeSizeOfRamLabel.Text = "1024";
            // 
            // ramInfoLabel
            // 
            ramInfoLabel.AutoSize = true;
            ramInfoLabel.Location = new Point(15, 477);
            ramInfoLabel.Name = "ramInfoLabel";
            ramInfoLabel.Size = new Size(209, 40);
            ramInfoLabel.TabIndex = 0;
            ramInfoLabel.Text = "Оперативна пам'ять\r\nРозмір оперативної пам'яті: ";
            // 
            // ramSizeBusyInfoLabel
            // 
            ramSizeBusyInfoLabel.AutoSize = true;
            ramSizeBusyInfoLabel.Location = new Point(15, 522);
            ramSizeBusyInfoLabel.Name = "ramSizeBusyInfoLabel";
            ramSizeBusyInfoLabel.Size = new Size(215, 20);
            ramSizeBusyInfoLabel.TabIndex = 26;
            ramSizeBusyInfoLabel.Text = "Оперативної пам'яті зайнято:";
            // 
            // ramSizeBusyLabel
            // 
            ramSizeBusyLabel.AutoSize = true;
            ramSizeBusyLabel.Location = new Point(252, 524);
            ramSizeBusyLabel.Name = "ramSizeBusyLabel";
            ramSizeBusyLabel.Size = new Size(17, 20);
            ramSizeBusyLabel.TabIndex = 27;
            ramSizeBusyLabel.Text = "0";
            // 
            // quantLabel
            // 
            quantLabel.AutoSize = true;
            quantLabel.Location = new Point(439, 475);
            quantLabel.Name = "quantLabel";
            quantLabel.Size = new Size(70, 20);
            quantLabel.TabIndex = 28;
            quantLabel.Text = "Quantum";
            // 
            // quantumNumericUpDown
            // 
            quantumNumericUpDown.Location = new Point(441, 500);
            quantumNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            quantumNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantumNumericUpDown.Name = "quantumNumericUpDown";
            quantumNumericUpDown.Size = new Size(68, 27);
            quantumNumericUpDown.TabIndex = 29;
            quantumNumericUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            quantumNumericUpDown.ValueChanged += quantNumericUpDown_ValueChanged;
            // 
            // ramProgressBar
            // 
            ramProgressBar.BackColor = Color.White;
            ramProgressBar.ForeColor = Color.White;
            ramProgressBar.Location = new Point(185, 465);
            ramProgressBar.MarqueeAnimationSpeed = 0;
            ramProgressBar.Name = "ramProgressBar";
            ramProgressBar.Size = new Size(125, 29);
            ramProgressBar.Style = ProgressBarStyle.Continuous;
            ramProgressBar.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 587);
            Controls.Add(panel2);
            Controls.Add(ramProgressBar);
            Controls.Add(quantumNumericUpDown);
            Controls.Add(quantLabel);
            Controls.Add(ramSizeBusyLabel);
            Controls.Add(ramSizeBusyInfoLabel);
            Controls.Add(realTimeSizeOfRamLabel);
            Controls.Add(ramInfoLabel);
            Controls.Add(saveSattingsButton);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(nextStepButton);
            Controls.Add(start);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Симуляція комп'ютерної системи з алгоритмом планування \"HPF з квантуванням\"";
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)intensitynumericUpDown).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)minTimenumericUpDown).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maxTimenumericUpDown).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ramSizenumericUpDown).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addrMinnumericUpDown).EndInit();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addrMaxnumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)quantumNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer formTimer;
        private RichTextBox cpuQueueTextBox;
        private Button start;
        private Label stepLabel;
        private Label cpuTextBoxLabelConst;
        private RichTextBox deviceQueueTextBox;
        private Label deviceTextBoxLabelConst;
        private TextBox cpuActiveProcess;
        private TextBox deviceActiveProcess;
        private Button nextStepButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label1;
        private NumericUpDown intensitynumericUpDown;
        private Label label2;
        private NumericUpDown minTimenumericUpDown;
        private Label label3;
        private NumericUpDown maxTimenumericUpDown;
        private Label label4;
        private NumericUpDown ramSizenumericUpDown;
        private Label label5;
        private NumericUpDown addrMinnumericUpDown;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label6;
        private NumericUpDown addrMaxnumericUpDown;
        private Label label7;
        private Label label8;
        private Button saveSattingsButton;
        private Panel panel1;
        private Label realTimeSizeOfRamLabel;
        private Label ramInfoLabel;
        private Label ramSizeBusyInfoLabel;
        private Label ramSizeBusyLabel;
        private Label quantLabel;
        private NumericUpDown quantumNumericUpDown;
        private ProgressBar ramProgressBar;
        private Panel panel2;
    }
}
