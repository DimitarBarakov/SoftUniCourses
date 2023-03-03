using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int killerThread = 0;
            while (true)
            {
                int currTask = tasks.Peek();
                int currThread = threads.Peek();
                if (currTask == taskToBeKilled)
                {
                    killerThread = currThread;
                    break;
                }
                else
                {
                    if (currThread >= currTask)
                    {
                        tasks.Pop();
                        threads.Dequeue();
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                }
            }
            Console.WriteLine($"Thread with value {killerThread} killed task {taskToBeKilled}");
            Console.WriteLine(String.Join(" ",threads));
        }   
    }
}
