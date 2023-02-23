using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>(); 
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 0);
                }
                nums[num]++;
            }
            //Dictionary<int, int> even = new Dictionary<int, int>();
            //even = nums.Where(n => n.Value % 2 == 0).ToDictionary(n => n.Key, n => n.Value);
            foreach (var item in nums)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
                
            }
        }
    }
}
