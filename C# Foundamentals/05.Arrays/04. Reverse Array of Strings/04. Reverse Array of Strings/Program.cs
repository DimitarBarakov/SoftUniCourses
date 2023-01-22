using System;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ');
            //Array.Reverse(arr);
            //Console.WriteLine(string.Join(' ',arr));
            for (int i = 0; i < arr.Length/2; i++)
            {
                string temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
