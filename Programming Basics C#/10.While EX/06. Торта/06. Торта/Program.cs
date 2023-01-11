using System;

namespace _06._Торта
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());
            int cakePieces = cakeLength * cakeWidth;
            int takenPieces = 0;
            string comm = Console.ReadLine();
            while (comm != "STOP")
            {
                int pieces = int.Parse(comm);
                takenPieces += pieces;
                if (takenPieces > cakePieces)
                {
                    Console.WriteLine($"No more cake left! You need {takenPieces - cakePieces} pieces more.");
                    return;
                }
                comm = Console.ReadLine();
            }
            Console.WriteLine($"{cakePieces-takenPieces} pieces are left.");
        }
    }
}
