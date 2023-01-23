using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());
            int rotations = array.Length - index;
            for (int i = 1; i <= rotations; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int temp = array[j+1];
                    array[j+1] = array[j];
                    array[j] = temp;
                }
            }
            Console.WriteLine(String.Join(" ",array));
        }
    }
}
