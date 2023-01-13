using System;

namespace Задача_4._Игра_на_карти_Number_wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondplayer = Console.ReadLine();
            int firsPlayerPoints = 0;
            int secPlayerPoints = 0;
            string command = Console.ReadLine();
            while (command!= "End of game")
            {
                int firstCard = int.Parse(command);
                int secondCard = int.Parse(Console.ReadLine());
                if (firstCard>secondCard)
                {
                    firsPlayerPoints += firstCard - secondCard;
                }
                else if (firstCard < secondCard)
                {
                    secPlayerPoints += secondCard - firstCard;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    firstCard = int.Parse(Console.ReadLine());
                    secondCard = int.Parse(Console.ReadLine());
                    if (firstCard>secondCard)
                    {
                        Console.WriteLine($"{firstPlayer} is winner with {firsPlayerPoints} points");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{secondplayer} is winner with {secPlayerPoints} points");
                        return;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{firstPlayer} has {firsPlayerPoints} points");
            Console.WriteLine($"{secondplayer} has {secPlayerPoints} points");
        }
    }
}
