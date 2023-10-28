using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessSchedulerSimulator
{
    public partial class MainForm : Form
    {
        private List<Process> processes = new List<Process>();
        private SchedulingAlgorithm selectedAlgorithm = SchedulingAlgorithm.FCFS;
        private int currentTime = 0;
        private Process currentProcess = null;
        private Timer executionTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            AlgorithmComboBox.Items.Add("FCFS");
            AlgorithmComboBox.Items.Add("SJF Preemptive");
            AlgorithmComboBox.SelectedIndex = 0;

            ProcessListView.View = View.Details;
            ProcessListView.GridLines = true;

            ProcessListView.Columns.Add("ID", 50, HorizontalAlignment.Left);
            ProcessListView.Columns.Add("Имя", 100, HorizontalAlignment.Left);
            ProcessListView.Columns.Add("Время CPU", 100, HorizontalAlignment.Left);
            ProcessListView.Columns.Add("Время прибытия", 100, HorizontalAlignment.Left);
            ProcessListView.Columns.Add("Status", 100, HorizontalAlignment.Left);

            executionTimer.Interval = 1000; // Интервал таймера в миллисекундах (1 секунда)
            executionTimer.Tick += ExecutionTimer_Tick;
            executionTimer.Enabled = true;
        }

        private void ExecutionTimer_Tick(object sender, EventArgs e)
        {
            currentTime++;

            // Если есть текущий процесс, уменьшить его время выполнения
            if (currentProcess != null)
            {
                currentProcess.CpuBurstTime--;

                if (currentProcess.CpuBurstTime == 0)
                {
                    // Процесс завершил выполнение, уберите его из списка
                    processes.Remove(currentProcess);
                    currentProcess = null;

                    // Если есть другие процессы, выберите следующий для выполнения
                    if (processes.Count > 0)
                        currentProcess = processes[0];
                }
            }

            // Вызвать метод обновления списка процессов
            UpdateProcessListView();

            // Обновить Label с текущим временем
            UpdateTimeLabel();
        }

        private void AddProcessButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ProcessIdTextBox.Text);
            string name = ProcessNameTextBox.Text;
            int burstTime = int.Parse(CpuBurstTimeTextBox.Text);
            int arrivalTime = currentTime;

            Process newProcess = new Process(id, name, burstTime, arrivalTime);

            if (selectedAlgorithm == SchedulingAlgorithm.SJFPreemptive)
            {
                if (currentProcess == null || newProcess.CpuBurstTime < currentProcess.CpuBurstTime)
                {
                    // Если нет текущего выполняющегося процесса или новый процесс имеет меньшее время выполнения,
                    // то новый процесс начнет выполнение сразу.
                    currentProcess = newProcess;
                    processes.Insert(0, newProcess);
                }
                else
                {
                    // Для SJF вытесняющего, вставляем новый процесс в правильное место с использованием бинарного поиска
                    int index = processes.BinarySearch(newProcess, new ProcessComparer());
                    if (index < 0)
                    {
                        index = ~index;
                    }
                    processes.Insert(index, newProcess);
                }
            }
            else
            {
                // Для других алгоритмов, добавляем новый процесс в конец списка
                processes.Add(newProcess);
            }

            ProcessIdTextBox.Clear();
            ProcessNameTextBox.Clear();
            CpuBurstTimeTextBox.Clear();

            UpdateProcessListView();
        }

        class ProcessComparer : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                // Сравниваем процессы по времени исполнения
                return x.CpuBurstTime.CompareTo(y.CpuBurstTime);
            }
        }


        private void SortProcesses()
        {
            switch (selectedAlgorithm)
            {
                case SchedulingAlgorithm.FCFS:
                    //Сортируем процессы по времени прибытия (сортировка не потребовалась бы, если бы этот алгоритм был единственным)
                    processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));
                    break;
                case SchedulingAlgorithm.SJFPreemptive:
                    // Сортируем процессы по времени исполнения (CpuBurstTime)
                    processes.Sort((p1, p2) => p1.CpuBurstTime.CompareTo(p2.CpuBurstTime));
                    break;
            }
        }

        private void UpdateProcessListView()
        {
            ProcessListView.Items.Clear();

            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.Id.ToString());
                item.SubItems.Add(process.Name);
                item.SubItems.Add(process.CpuBurstTime.ToString());
                item.SubItems.Add(process.ArrivalTime.ToString());

                string status = (process == currentProcess) ? "Исполнение" : "Готовность";
                item.SubItems.Add(status);

                ProcessListView.Items.Add(item);
            }
        }

        private void UpdateTimeLabel()
        {
            // Обновите Label с текущим временем
            TimeLabel.Text = "Time: " + currentTime;

        }

        private void RunSchedulerButton_Click_1(object sender, EventArgs e)
        {
            switch (AlgorithmComboBox.SelectedIndex)
            {
                case 0:
                    selectedAlgorithm = SchedulingAlgorithm.FCFS;
                    break;
                case 1:
                    selectedAlgorithm = SchedulingAlgorithm.SJFPreemptive;
                    break;
            }

            SortProcesses();

            // Начать выполнение процессов
            if (processes.Count > 0)
            {
                currentProcess = processes[0]; 
            }
        }
    }
}
