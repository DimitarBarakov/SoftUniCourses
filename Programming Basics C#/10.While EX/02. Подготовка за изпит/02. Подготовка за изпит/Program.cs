using System;

namespace _02._Подготовка_за_изпит
{
    class Program
    {
        static void Main(string[] args)
        {
            int NeededBadMarksCount = int.Parse(Console.ReadLine());
            int badMarksCount = 0;
            int allMarksCount = 0;
            double marks = 0;
            int taskCount = 0;
            string task = Console.ReadLine();
            string lastTask = "";
            while (task!="Enough")
            {
                taskCount++;
                double taskMarks = double.Parse(Console.ReadLine());
                allMarksCount++;
                marks += taskMarks;
                if (taskMarks <= 4)
                {
                    badMarksCount++;
                }
                if (badMarksCount==NeededBadMarksCount)
                {
                    Console.WriteLine($"You need a break, {badMarksCount} poor grades.");
                    return;
                }
                task = Console.ReadLine();
                if (task!="Enough")
                {
                    lastTask = task;
                }
            }
            Console.WriteLine($"Average score: {marks/allMarksCount:f2}");
            Console.WriteLine($"Number of problems: {taskCount}");
            Console.WriteLine($"Last problem: {lastTask}");
        }
    }
}
