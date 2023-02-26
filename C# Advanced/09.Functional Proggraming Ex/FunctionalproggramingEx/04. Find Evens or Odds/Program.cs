using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isOddOrEven = x => x % 2 == 0;
            int[] arg = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string condition = Console.ReadLine();
            int start = arg[0];
            int end = arg[1];
            if (condition == "odd")
            {
                for (int i = start; i <= end; i++)
                {
                    if (!isOddOrEven(i))
                    {
                        Console.Write(i+" ");
                    }
                }
            }
            else
            {
                for(int i = start; i <= end; i++)
                {
                    if (isOddOrEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            
        }
    }
}
