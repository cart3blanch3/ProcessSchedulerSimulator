using System;

namespace ProcessSchedulerSimulator
{
    partial class MainForm
    {
        // Добавьте объявления элементов управления здесь
        private System.Windows.Forms.Button AddProcessButton;
        private System.Windows.Forms.TextBox ProcessIdTextBox;
        private System.Windows.Forms.TextBox ProcessNameTextBox;
        private System.Windows.Forms.TextBox CpuBurstTimeTextBox;
        private System.Windows.Forms.ListView ProcessListView;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.Button RunSchedulerButton;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label ProcessIdLabel;
        private System.Windows.Forms.Label ProcessNameLabel; 
        private System.Windows.Forms.Label CpuBurstTimeLabel; 

        private void InitializeComponent()
        {
            this.AddProcessButton = new System.Windows.Forms.Button();
            this.ProcessIdTextBox = new System.Windows.Forms.TextBox();
            this.ProcessNameTextBox = new System.Windows.Forms.TextBox();
            this.CpuBurstTimeTextBox = new System.Windows.Forms.TextBox();
            this.ProcessListView = new System.Windows.Forms.ListView();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.RunSchedulerButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ProcessIdLabel = new System.Windows.Forms.Label();
            this.ProcessNameLabel = new System.Windows.Forms.Label();
            this.CpuBurstTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddProcessButton
            // 
            this.AddProcessButton.Location = new System.Drawing.Point(612, 126);
            this.AddProcessButton.Name = "AddProcessButton";
            this.AddProcessButton.Size = new System.Drawing.Size(100, 30);
            this.AddProcessButton.TabIndex = 0;
            this.AddProcessButton.Text = "Добавить";
            this.AddProcessButton.Click += new System.EventHandler(this.AddProcessButton_Click);
            // 
            // ProcessIdTextBox
            // 
            this.ProcessIdTextBox.Location = new System.Drawing.Point(705, 9);
            this.ProcessIdTextBox.Name = "ProcessIdTextBox";
            this.ProcessIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.ProcessIdTextBox.TabIndex = 1;
            // 
            // ProcessNameTextBox
            // 
            this.ProcessNameTextBox.Location = new System.Drawing.Point(705, 40);
            this.ProcessNameTextBox.Name = "ProcessNameTextBox";
            this.ProcessNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.ProcessNameTextBox.TabIndex = 2;
            // 
            // CpuBurstTimeTextBox
            // 
            this.CpuBurstTimeTextBox.Location = new System.Drawing.Point(705, 65);
            this.CpuBurstTimeTextBox.Name = "CpuBurstTimeTextBox";
            this.CpuBurstTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.CpuBurstTimeTextBox.TabIndex = 3;
            // 
            // ProcessListView
            // 
            this.ProcessListView.HideSelection = false;
            this.ProcessListView.Location = new System.Drawing.Point(12, 12);
            this.ProcessListView.Name = "ProcessListView";
            this.ProcessListView.Size = new System.Drawing.Size(577, 280);
            this.ProcessListView.TabIndex = 6;
            this.ProcessListView.UseCompatibleStateImageBehavior = false;
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.Location = new System.Drawing.Point(387, 351);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(121, 24);
            this.AlgorithmComboBox.TabIndex = 7;
            this.AlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmComboBox_SelectedIndexChanged);
            // 
            // RunSchedulerButton
            // 
            this.RunSchedulerButton.Location = new System.Drawing.Point(406, 322);
            this.RunSchedulerButton.Name = "RunSchedulerButton";
            this.RunSchedulerButton.Size = new System.Drawing.Size(93, 23);
            this.RunSchedulerButton.TabIndex = 8;
            this.RunSchedulerButton.Text = "Запустить";
            this.RunSchedulerButton.Click += new System.EventHandler(this.RunSchedulerButton_Click_1);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(611, 285);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(61, 16);
            this.TimeLabel.TabIndex = 9;
            this.TimeLabel.Text = "Время: 0";
            // 
            // ProcessIdLabel
            // 
            this.ProcessIdLabel.AutoSize = true;
            this.ProcessIdLabel.Location = new System.Drawing.Point(611, 12);
            this.ProcessIdLabel.Name = "ProcessIdLabel";
            this.ProcessIdLabel.Size = new System.Drawing.Size(88, 16);
            this.ProcessIdLabel.TabIndex = 10;
            this.ProcessIdLabel.Text = "ID процесса:";
            // 
            // ProcessNameLabel
            // 
            this.ProcessNameLabel.AutoSize = true;
            this.ProcessNameLabel.Location = new System.Drawing.Point(611, 40);
            this.ProcessNameLabel.Name = "ProcessNameLabel";
            this.ProcessNameLabel.Size = new System.Drawing.Size(101, 16);
            this.ProcessNameLabel.TabIndex = 11;
            this.ProcessNameLabel.Text = "Имя процесса:";
            // 
            // CpuBurstTimeLabel
            // 
            this.CpuBurstTimeLabel.AutoSize = true;
            this.CpuBurstTimeLabel.Location = new System.Drawing.Point(611, 68);
            this.CpuBurstTimeLabel.Name = "CpuBurstTimeLabel";
            this.CpuBurstTimeLabel.Size = new System.Drawing.Size(82, 16);
            this.CpuBurstTimeLabel.TabIndex = 12;
            this.CpuBurstTimeLabel.Text = "Время CPU:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(830, 429);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ProcessIdLabel);
            this.Controls.Add(this.ProcessNameLabel);
            this.Controls.Add(this.CpuBurstTimeLabel);
            this.Controls.Add(this.AddProcessButton);
            this.Controls.Add(this.ProcessIdTextBox);
            this.Controls.Add(this.ProcessNameTextBox);
            this.Controls.Add(this.CpuBurstTimeTextBox);
            this.Controls.Add(this.ProcessListView);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.RunSchedulerButton);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получите выбранный индекс в ComboBox
            int selectedIndex = AlgorithmComboBox.SelectedIndex;

            // В зависимости от выбранного индекса, обновите текущий выбранный алгоритм
            switch (selectedIndex)
            {
                case 0:
                    selectedAlgorithm = SchedulingAlgorithm.FCFS;
                    break;
                case 1:
                    selectedAlgorithm = SchedulingAlgorithm.SJFNonPreemptive;
                    break;
                    // Добавьте другие алгоритмы по мере необходимости
            }
        }
    }
}
