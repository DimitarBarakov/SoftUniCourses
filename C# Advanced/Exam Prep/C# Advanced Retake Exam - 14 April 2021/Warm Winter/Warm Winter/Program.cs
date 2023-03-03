using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> sets = new List<int>();
            while (hats.Count > 0 && scarfs.Count>0)
            {
                int currHat = hats.Peek();
                int currScarf = scarfs.Peek();

                if (currHat > currScarf)
                {
                    int set = currHat + currScarf;
                    hats.Pop();
                    scarfs.Dequeue();
                    sets.Add(set);
                }
                else if (currScarf > currHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    currHat++;
                    hats.Pop();
                    hats.Push(currHat);
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(String.Join(" ",sets));
        }
    }
}
