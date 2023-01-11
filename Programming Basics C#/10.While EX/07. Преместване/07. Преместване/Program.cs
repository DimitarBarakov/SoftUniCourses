using System;

namespace _07._Преместване
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            int freeSpace = width * length * heigth;
            int takenSpace = 0;
            string comm = Console.ReadLine();
            while (comm!="Done")
            {
                int boxesSpace = int.Parse(comm);
                takenSpace += boxesSpace;
                if (takenSpace>freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {takenSpace-freeSpace} Cubic meters more.");
                    return;
                }
                comm = Console.ReadLine();
            }
            Console.WriteLine($"{freeSpace-takenSpace} Cubic meters left.");
        }
    }
}
