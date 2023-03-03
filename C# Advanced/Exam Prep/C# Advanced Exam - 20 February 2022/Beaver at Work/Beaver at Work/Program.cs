using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pondSize = int.Parse(Console.ReadLine());
            char[,] pond = new char[pondSize, pondSize];
            int beaverRowIndex = 0;
            int beaverColumnIndex = 0;
            for (int row = 0; row < pondSize; row++)
            {
                char[] elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < pondSize; col++)
                {
                    pond[row, col] = elements[col];
                    if (pond[row, col] == 'B')
                    {
                        beaverRowIndex = row;
                        beaverColumnIndex = col;
                    }
                }
            }
            Stack<char> collectedWoodBranches = new Stack<char>();
            int branchesLeft = 0;
            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "down")
                {
                    if (beaverRowIndex + 1 == pondSize)
                    {
                        if (collectedWoodBranches.Count > 0)
                        {
                            collectedWoodBranches.Pop();
                        }
                    }
                    else
                    {
                        pond[beaverRowIndex, beaverColumnIndex] = '-';
                        beaverRowIndex++;
                        if (pond[beaverRowIndex, beaverColumnIndex] == 'F')
                        {
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                            if (beaverRowIndex == pondSize - 1)
                            {
                                beaverRowIndex = 0;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                            else
                            {
                                beaverRowIndex = pondSize - 1;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                        }
                        else if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                        {
                            collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                        }
                        pond[beaverRowIndex, beaverColumnIndex] = 'B';
                    }
                }
                else if (cmd == "up")
                {
                    if (beaverRowIndex - 1 == -1)
                    {
                        if (collectedWoodBranches.Count > 0)
                        {
                            collectedWoodBranches.Pop();
                        }
                    }
                    else
                    {
                        pond[beaverRowIndex, beaverColumnIndex] = '-';
                        beaverRowIndex--;
                        if (pond[beaverRowIndex, beaverColumnIndex] == 'F')
                        {
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                            if (beaverRowIndex == 0)
                            {
                                beaverRowIndex = pondSize - 1;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                            else
                            {
                                beaverRowIndex = 0;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                        }
                        else if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                        {
                            collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                        }
                        pond[beaverRowIndex, beaverColumnIndex] = 'B';
                    }
                }
                else if (cmd == "right")
                {
                    if (beaverColumnIndex + 1 == pondSize)
                    {
                        if (collectedWoodBranches.Count > 0)
                        {
                            collectedWoodBranches.Pop();
                        }
                    }
                    else
                    {
                        pond[beaverRowIndex, beaverColumnIndex] = '-';
                        beaverColumnIndex++;
                        if (pond[beaverRowIndex, beaverColumnIndex] == 'F')
                        {
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                            if (beaverColumnIndex == pondSize - 1)
                            {
                                beaverColumnIndex = 0;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                            else
                            {
                                beaverColumnIndex = pondSize - 1;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                        }
                        else if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                        {
                            collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                        }
                        pond[beaverRowIndex, beaverColumnIndex] = 'B';
                    }
                }
                else if (cmd == "left")
                {
                    if (beaverColumnIndex - 1 == -1)
                    {
                        if (collectedWoodBranches.Count > 0)
                        {
                            collectedWoodBranches.Pop();
                        }
                        }
                    else
                    {
                        pond[beaverRowIndex, beaverColumnIndex] = '-';
                        beaverColumnIndex--;
                        if (pond[beaverRowIndex, beaverColumnIndex] == 'F')
                        {
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                            if (beaverColumnIndex == 0)
                            {
                                beaverColumnIndex = pondSize - 1;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                            else
                            {
                                beaverColumnIndex = 0;
                                if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                                {
                                    collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                                    pond[beaverRowIndex, beaverColumnIndex] = '-';
                                }
                            }
                        }
                        else if (Char.IsLetter(pond[beaverRowIndex, beaverColumnIndex]) && Char.IsLower(pond[beaverRowIndex, beaverColumnIndex]))
                        {
                            collectedWoodBranches.Push(pond[beaverRowIndex, beaverColumnIndex]);
                            pond[beaverRowIndex, beaverColumnIndex] = '-';
                        }
                        pond[beaverRowIndex, beaverColumnIndex] = 'B';
                    }
                }
                bool isThereAnyLeft = false;
                for (int row = 0; row < pondSize; row++)
                {
                    for (int col = 0; col < pondSize; col++)
                    {
                        if (Char.IsLetter(pond[row, col]) && Char.IsLower(pond[row, col]))
                        {
                            isThereAnyLeft = true;
                            break;
                        }
                    }
                    if (isThereAnyLeft)
                    {
                        break;
                    }
                }
                if (!isThereAnyLeft)
                {
                    break;
                }
            }
            for (int row = 0; row < pondSize; row++)
            {
                for (int col = 0; col < pondSize; col++)
                {
                    if (Char.IsLetter(pond[row, col]) && Char.IsLower(pond[row, col]))
                    {
                        branchesLeft++;
                    }
                }
            }
            if (branchesLeft == 0)
            {
                Console.WriteLine($"The Beaver successfully collect { collectedWoodBranches.Count} wood branches: {string.Join(", ", collectedWoodBranches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
            }


            for (int row = 0; row < pondSize; row++)
            {
                for (int col = 0; col < pondSize; col++)
                {
                    Console.Write(pond[row, col]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
