using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int sumBefore = 0;
                int sumAfter = 0;
                for (int elBeforeI = 0; elBeforeI < i; elBeforeI++)
                {
                    sumBefore += arr[elBeforeI];
                }
                for (int elAfterI = i+1; elAfterI < arr.Length; elAfterI++)
                {
                    sumAfter += arr[elAfterI];
                }
                if (sumBefore==sumAfter)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
