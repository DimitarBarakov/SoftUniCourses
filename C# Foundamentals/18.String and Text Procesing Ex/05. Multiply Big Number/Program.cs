using System;
using System.Numerics;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = BigInteger.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            BigInteger sum = a * b;
            Console.WriteLine(sum);
        }
    }
}
