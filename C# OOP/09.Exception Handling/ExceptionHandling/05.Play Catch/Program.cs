using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int exceptionCounter = 0;

            while (exceptionCounter < 3)
            {
                string[] tokens = Console.ReadLine().Split();
                string type = tokens[0];
                if (type == "Replace")
                {
                    try
                    {
                        int index = int.Parse(tokens[1]);
                        int el = int.Parse(tokens[2]);
                        Replace(nums, index, el);
                    }
                    catch (ArgumentOutOfRangeException ae)
                    {
                        Console.WriteLine("The index does not exist!");
                        exceptionCounter++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        exceptionCounter++;
                    } 
                }
                else if (type == "Print")
                {
                    try
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        Console.WriteLine(string.Join(", ",Print(nums, startIndex, endIndex)));
                    }
                    catch (ArgumentOutOfRangeException ae)
                    {
                        Console.WriteLine("The index does not exist!");
                        exceptionCounter++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        exceptionCounter++;
                    }
                }
                else if (type == "Show")
                {
                    try
                    {
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(Show(nums, index));
                    }
                    catch (ArgumentOutOfRangeException ae)
                    {
                        Console.WriteLine("The index does not exist!");
                        exceptionCounter++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        exceptionCounter++;
                    }
                }
            }

            Console.WriteLine(String.Join(", ",nums));
        }

        public static bool IsIndexValid(int index,List<int> nums)
        {
            if (index < 0 || index >= nums.Count)
            {
                return false;
            }
            return true;
        }
        public static void Replace(List<int> nums, int index, int el)
        {
            if (!IsIndexValid(index,nums))
            {
                throw new ArgumentOutOfRangeException("The index does not exist!");
            }
            nums[index] = el;
        }

        public static List<int> Print(List<int> nums, int startIndex, int endIndex)
        {
            List<int> numsToPrint = new List<int>();
            if (!IsIndexValid(startIndex, nums) || !IsIndexValid(endIndex, nums))
            {
                throw new ArgumentOutOfRangeException("The index does not exist!");
            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                numsToPrint.Add(nums[i]);
            }

            return numsToPrint;
        }

        public static int Show(List<int> nums, int index)
        {
            if (!IsIndexValid(index, nums))
            {
                throw new ArgumentOutOfRangeException("The index does not exist!");
            }
            return nums[index];
        }
    }
}
