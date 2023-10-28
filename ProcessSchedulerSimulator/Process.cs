public class Process
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CpuBurstTime { get; set; }
    public int ArrivalTime { get; set; }
    public int Priority { get; set; }

    public Process(int id, string name, int burstTime, int arrivalTime)
    {
        Id = id;
        Name = name;
        CpuBurstTime = burstTime;
        ArrivalTime = arrivalTime;
    }
}
