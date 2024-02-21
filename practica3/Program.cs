using System;
using System.Collections.Generic;

public class Process
{
    public int ID { get; set; }
    public int ExecutionTime { get; set; }
    public int Priority { get; set; }
}

public class Practica3
{
    public static void FIFO(List<Process> processes)
    {
        Queue<Process> processQueue = new Queue<Process>();
        foreach (var process in processes)
        {
            processQueue.Enqueue(process);
        }

        while (processQueue.Count > 0)
        {
            Process currentProcess = processQueue.Dequeue();
            Console.WriteLine($"Процесс выполнения {currentProcess.ID} Время выполнения {currentProcess.ExecutionTime} Приоритет {currentProcess.Priority}");
            System.Threading.Thread.Sleep(currentProcess.ExecutionTime); 
        }
    }
    public static void SJF(List<Process> processes)
    {
        processes.Sort((x, y) => x.ExecutionTime.CompareTo(y.ExecutionTime)); 
        foreach (var process in processes)
        {
            Console.WriteLine($"Процес выполнение {process.ID} Время выполнения {process.ExecutionTime} Приоритет {process.Priority}");
            System.Threading.Thread.Sleep(process.ExecutionTime); 
        }
    }
    public static void RoundRobin(List<Process> processes, int timeQuantum)
    {
        Queue<Process> processQueue = new Queue<Process>(processes);
        while (processQueue.Count > 0)
        {
            Process currentProcess = processQueue.Dequeue();
            int remainingTime = currentProcess.ExecutionTime;
            while (remainingTime > 0)
            {
                int executionTime = Math.Min(remainingTime, timeQuantum);
                Console.WriteLine($"Процес выполнение {currentProcess.ID} Время выполнения {executionTime} Приоритет {currentProcess.Priority}");
                System.Threading.Thread.Sleep(executionTime);
                remainingTime -= executionTime;

                if (remainingTime > 0)
                {
                    processQueue.Enqueue(currentProcess);
                }
            }
        }
    }
    public static void Main()
    {
        List<Process> fifoProcesses = new List<Process>
        {
            new Process { ID = 1, ExecutionTime = 5, Priority = 1 },
            new Process { ID = 2, ExecutionTime = 3, Priority = 2 },
            new Process { ID = 3, ExecutionTime = 7, Priority = 3 }
        };

        List<Process> sjfProcesses = new List<Process>
        {
            new Process { ID = 1, ExecutionTime = 2, Priority = 1 },
            new Process { ID = 2, ExecutionTime = 5, Priority = 2 },
            new Process { ID = 3, ExecutionTime = 3, Priority = 3 }
        };

        List<Process> roundRobinProcesses = new List<Process>
        {
            new Process { ID = 1, ExecutionTime = 7, Priority = 1 },
            new Process { ID = 2, ExecutionTime = 4, Priority = 2 },
            new Process { ID = 3, ExecutionTime = 2, Priority = 3 }
        };
        Console.WriteLine("Алгоритм FIFO Scheduling:");
        FIFO(fifoProcesses);
        Console.WriteLine("Алгоритм SJF Scheduling:");
        SJF(sjfProcesses);
        Console.WriteLine("Алгоритм Round Robin Scheduling:");
        RoundRobin(roundRobinProcesses, 3);
    }
}