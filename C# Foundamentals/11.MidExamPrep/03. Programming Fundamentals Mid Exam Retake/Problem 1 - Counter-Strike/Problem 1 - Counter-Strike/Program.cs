using System;

namespace Problem_1___Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command;
            int wonBatles = 0;
            while ((command = Console.ReadLine())!= "End of battle")
            {
                int distance = int.Parse(command);
                if (energy >= distance)
                {
                    energy -= distance;
                    wonBatles++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBatles} won battles and {energy} energy");
                    return;
                }
                if (wonBatles % 3 == 0)
                {
                    energy += wonBatles;
                }

            }
            Console.WriteLine($"Won battles: {wonBatles}. Energy left: {energy}");
        }
    }
}
