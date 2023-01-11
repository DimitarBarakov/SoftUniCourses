using System;

namespace _04._Стъпки
{
    class Program
    {
        static void Main(string[] args)
        {
            int madeSteps = 0;
            while (madeSteps<10000)
            {
                int steps;
                string comm = Console.ReadLine();
                if (comm=="Going home")
                {
                    comm = Console.ReadLine();
                    steps = int.Parse(comm);
                    madeSteps += steps;
                    if (madeSteps>=10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{madeSteps-10000} steps over the goal!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{10000-madeSteps} more steps to reach goal.");
                        return;
                    }
                }
                else
                {
                    steps = int.Parse(comm);
                }
                madeSteps += steps;
            }
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{madeSteps - 10000} steps over the goal!");
        }
    }
}
