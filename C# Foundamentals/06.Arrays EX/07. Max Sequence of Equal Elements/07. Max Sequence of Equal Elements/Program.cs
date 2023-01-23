using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxSequenceCount = 1;
            int maxsequenceElement = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int currentSequenceCount = 1;
                int j = i + 1;
                while (arr[i] == arr[j])
                {
                    currentSequenceCount++;
                    j++;
                    if (j>=arr.Length)
                    {
                        break;
                    }
                }
                if (currentSequenceCount > maxSequenceCount)
                {
                    maxSequenceCount = currentSequenceCount;
                    maxsequenceElement = arr[i];
                }
            }
            for (int i = 1; i <= maxSequenceCount; i++)
            {
                Console.Write(maxsequenceElement + " ");
            }
        }
    }
}
