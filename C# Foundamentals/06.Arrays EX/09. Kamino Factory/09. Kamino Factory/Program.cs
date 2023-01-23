using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string command;
            int leftmostIndex = sequenceLength;
            int longestSubsequenceCount = 0;
            int maxSum = 0;
            int sequencesCounter = 1;
            int bestSequenceIndex = 0;
            int[] best = new int[sequenceLength];
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] dna = new int[sequenceLength];
                dna = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int cutrrentDnaMaxSequenceCount = 0;
                int currentDnaleftmostIndex = sequenceLength;
                int currentSum = dna.Sum();
                for (int i = 0; i < sequenceLength; i++)
                {
                    int currentDnaSequenceCount = 0;
                    int currentIndex = i;
                    while (dna[currentIndex] == 1)
                    {
                        currentDnaSequenceCount++;
                        currentIndex++;
                        if (currentIndex >= dna.Length)
                        {
                            break;
                        }
                    }
                    if (currentDnaSequenceCount > cutrrentDnaMaxSequenceCount)
                    {
                        cutrrentDnaMaxSequenceCount = currentDnaSequenceCount;
                        currentDnaleftmostIndex = i;
                    }
                }
                if (cutrrentDnaMaxSequenceCount > longestSubsequenceCount)
                {
                    longestSubsequenceCount = cutrrentDnaMaxSequenceCount;
                    best = dna;
                    bestSequenceIndex = sequencesCounter;
                    maxSum = currentSum;
                    leftmostIndex = currentDnaleftmostIndex;
                }
                else if (cutrrentDnaMaxSequenceCount == longestSubsequenceCount)
                {
                    if (currentDnaleftmostIndex < leftmostIndex)
                    {
                        longestSubsequenceCount = cutrrentDnaMaxSequenceCount;
                        best = dna;
                        bestSequenceIndex = sequencesCounter;
                        maxSum = currentSum;
                    }
                    else if (currentDnaleftmostIndex == leftmostIndex)
                    {
                        if (currentSum > maxSum)
                        {
                            longestSubsequenceCount = cutrrentDnaMaxSequenceCount;
                            best = dna;
                            maxSum = currentSum;
                            bestSequenceIndex = sequencesCounter;
                        }
                    }
                }
                sequencesCounter++;
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {maxSum}.");
            Console.WriteLine(String.Join(' ', best));
        }
    }
}
