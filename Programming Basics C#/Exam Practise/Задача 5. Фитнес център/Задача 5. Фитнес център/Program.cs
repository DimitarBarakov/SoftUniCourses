using System;

namespace Задача_5._Фитнес_център
{
    class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());
            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int shake = 0;
            int bar = 0;
            int trainers = 0;
            int buyers = 0;
            for (int i = 1; i <= clients; i++)
            {
                string workout = Console.ReadLine();
                if (workout=="Back")
                {
                    back++;
                    trainers++;
                }
                else if (workout=="Chest")
                {
                    chest++;
                    trainers++;
                }
                else if (workout == "Legs")
                {
                    legs++;
                    trainers++;
                }
                else if (workout == "Abs")
                {
                    abs++;
                    trainers++;
                }
                else if (workout == "Protein shake")
                {
                    shake++;
                    buyers++;
                }
                else if (workout == "Protein bar")
                {
                    bar++;
                    buyers++;
                }
            }
            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{shake} - protein shake");
            Console.WriteLine($"{bar} - protein bar");
            Console.WriteLine($"{trainers*1.0/clients*100:f2}% - work out");
            Console.WriteLine($"{buyers*1.0/clients*100:f2}% - protein");
        }
    }
}
