using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> produscts = Console.ReadLine().Split().Where(x => x.Length%2==0).ToList();
            foreach (var produs in produscts)
            {
                Console.WriteLine(produs);
            }
        }
    }
}
