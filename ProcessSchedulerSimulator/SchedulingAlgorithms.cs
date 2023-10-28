using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSchedulerSimulator
{
    public static class SchedulingAlgorithms
    {
        public static List<Process> FCFS(List<Process> processes)
        {
            // Простой алгоритм FCFS - просто оставляем процессы в том порядке, в котором они поступают.
            // Нет необходимости в сортировке, так как процессы выполняются в порядке появления.

            return processes;
        }

        public static List<Process> SJFNonPreemptive(List<Process> processes)
        {
            // Алгоритм SJF невытесняющий - выбираем процесс с наименьшим временем исполнения,
            // и он будет выполняться до завершения.

            // Сортируем процессы по времени исполнения (CpuBurstTime)
            processes.Sort((p1, p2) => p1.CpuBurstTime.CompareTo(p2.CpuBurstTime));

            return processes;
        }
    }
}
