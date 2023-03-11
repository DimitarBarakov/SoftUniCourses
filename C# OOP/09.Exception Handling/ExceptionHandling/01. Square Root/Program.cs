using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                double a = double.Parse(Console.ReadLine());
                double res = Math.Sqrt(a);
                Console.WriteLine(res);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
