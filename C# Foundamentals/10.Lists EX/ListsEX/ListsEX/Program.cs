using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsEX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList(); //qwe ab cd rty ghj
            int index = 1;
            int portions = 2;
            string elemnetToDivide = elements[index]; // abcd  -> ab cd
            int newElemnetsCount = elemnetToDivide.Length / portions;
            for (int i = 0; i < portions; i++)
            {
                string newElement = "";
                for (int j = 0; j < newElemnetsCount; j++)
                {
                    newElement += elemnetToDivide[i];
                }
            }
            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
