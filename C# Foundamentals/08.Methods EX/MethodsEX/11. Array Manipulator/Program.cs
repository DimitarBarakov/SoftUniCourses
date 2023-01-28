using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] comm = command.Split();
                string action = comm[0];
                if (action == "exchange")
                {
                    int index = int.Parse(comm[1]);
                    if (index < 0 || index >= arr.Length)
                    {
                        Console.WriteLine("Invalid index");

                    }
                    else
                    {
                        Exchange(arr, index);
                    }
                }
                else if (action == "max")
                {
                    string type = comm[1];
                    if (ReturnMaxEvenOddIndex(arr, type) == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(ReturnMaxEvenOddIndex(arr, type));
                    }
                }
                else if (action == "min")
                {
                    string type = comm[1];
                    if (ReturnMinEvenOddIndex(arr, type) == arr.Length)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(ReturnMinEvenOddIndex(arr, type));
                    }
                }
                else if (action == "first")
                {
                    int count = int.Parse(comm[1]);
                    string type = comm[2];
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (type == "even")
                        {
                            Console.WriteLine($"[{string.Join(", ", ReturnFirstEvenCount(arr, count))}]");
                        }
                        else
                        {
                            Console.WriteLine($"[{string.Join(", ", ReturnFirstOddCount(arr, count))}]");
                        }
                    }
                }
                else if (action == "last")
                {
                    int count = int.Parse(comm[1]);
                    string type = comm[2];
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (type == "even")
                        {
                            Console.WriteLine($"[{string.Join(", ", ReturnLastEvenCount(arr, count))}]");

                        }
                        else
                        {
                            Console.WriteLine($"[{string.Join(", ", ReturnLastOddCount(arr, count))}]");
                        }
                        
                    }
                }
            }
            Console.WriteLine($"[{String.Join(", ", arr)}]");
        }

        static int[] Exchange(int[] array, int index)
        {
            int rotations = index + 1;
            for (int i = 1; i <= rotations; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
            return array;
        }

        static int ReturnMaxEvenOddIndex(int[] arr, string type)
        {

            int maxEven = int.MinValue;
            int maxEvenIndex = -1;
            int maxOdd = int.MinValue;
            int maxOddIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] >= maxEven)
                {
                    maxEven = arr[i];
                    maxEvenIndex = i;
                }
                else if (arr[i] % 2 != 0 && arr[i] >= maxOdd)
                {
                    maxOdd = arr[i];
                    maxOddIndex = i;
                }
            }
            if (type == "even")
            {
                return maxEvenIndex;
            }
            else
            {
                return maxOddIndex;
            }
        }
        static int ReturnMinEvenOddIndex(int[] arr, string type)
        {

            int minEven = int.MaxValue;
            int minEvenIndex = arr.Length;
            int minOdd = int.MaxValue;
            int minOddIndex = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] <= minEven)
                {
                    minEven = arr[i];
                    minEvenIndex = i;
                }
                else if (arr[i] % 2 != 0 && arr[i] <= minOdd)
                {
                    minOdd = arr[i];
                    minOddIndex = i;
                }
            }
            if (type == "even")
            {
                return minEvenIndex;
            }
            else
            {
                return minOddIndex;
            }
        }

        static List<int> ReturnFirstEvenCount(int[] arr, int count)
        {
            List<int> firstEven = new List<int>();
            List<int> firstOdd = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    firstEven.Add(arr[i]);
                    if (firstEven.Count == count)
                    {
                        break;
                    }
                }
            }
            return firstEven;
        }

        static List<int> ReturnFirstOddCount(int[] arr, int count)
        {
            List<int> firstOdd = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] % 2 != 0)
                {
                    firstOdd.Add(arr[i]);
                    if (firstOdd.Count == count)
                    {
                        break;
                    }
                }

            }
            return firstOdd;
        }

        static List<int> ReturnLastEvenCount(int[] arr, int count)
        {
            List<int> lastEven = new List<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 == 0)
                {
                    lastEven.Add(arr[i]);
                    if (lastEven.Count == count)
                    {
                        break;
                    }
                }

            }
            lastEven.Reverse();
            return lastEven;
        }

        static List<int> ReturnLastOddCount(int[] arr, int count)
        {
            List<int> lastOdd = new List<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 != 0)
                {
                    lastOdd.Add(arr[i]);
                    if (lastOdd.Count == count)
                    {
                        break;
                    }
                }
            }
            lastOdd.Reverse();
            return lastOdd;
        }
    }
}
