using System;

namespace _06._Най_голямо_число
{
    class Program
    {
        static void Main(string[] args)
        {
            string comm = Console.ReadLine();
            int max = int.MinValue;
            while (comm!="Stop")
            {
                int num = int.Parse(comm);
                if (num>max)
                {
                    max = num;
                }
                comm = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}
