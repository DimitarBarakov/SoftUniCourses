using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int length = nums.Length;
            //for (int i = 0; i < length - 1; i++)
            //{
            //    int[] nums2 = new int[nums.Length - 1];
            //    for (int j = 0; j < nums.Length -1; j++)
            //    {
            //        nums2[j] = nums[j] + nums[j + 1];
            //    }
            //    nums = nums2;
            //}
            //Console.WriteLine(String.Join(" ", nums));
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int count = nums.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                for (int j = 0; j < nums.Count - 1; j++)
                {
                    nums[j] += nums[j + 1];
                }
                if (nums.Count>1)
                {
                    nums.RemoveAt(nums.Count - 1);
                }
                
            }
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
