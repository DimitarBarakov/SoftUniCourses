using System;
using System.Linq;

namespace Problem_2___Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "swap")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);
                    int temp = array[index1];
                    array[index1] = array[index2];
                    array[index2] = temp;
                }
                else if (action == "multiply")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    array[index1]*=array[index2];
                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i]--;
                    }
                }
            }
            Console.WriteLine(String.Join(", ", array));
        }
    }
}
