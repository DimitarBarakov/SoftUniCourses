using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++) numbers[i] = int.Parse(Console.ReadLine());
            Array.Reverse(numbers);
            Console.WriteLine(String.Join(' ',numbers));
        }
    }
}
