using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                int firstDeckCurrentCard = firstDeck[0];
                int secondDeckCurrentCard = secondDeck[0];
                if (firstDeckCurrentCard > secondDeckCurrentCard)
                {
                    firstDeck.Add(secondDeckCurrentCard);
                    firstDeck.Remove(firstDeckCurrentCard);
                    firstDeck.Add(firstDeckCurrentCard);
                    secondDeck.Remove(secondDeckCurrentCard);
                }
                else if (firstDeckCurrentCard < secondDeckCurrentCard) 
                {
                    secondDeck.Add(firstDeckCurrentCard);
                    secondDeck.Remove(secondDeckCurrentCard);
                    secondDeck.Add(secondDeckCurrentCard);
                    firstDeck.Remove(firstDeckCurrentCard);
                }
                else
                {
                    secondDeck.Remove(secondDeckCurrentCard);
                    firstDeck.Remove(firstDeckCurrentCard);
                }
            }
            if (secondDeck.Count>0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
            if (firstDeck.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
        }
    }
}
