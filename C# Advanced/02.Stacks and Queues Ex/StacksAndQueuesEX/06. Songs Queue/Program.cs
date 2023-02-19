using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            while (songs.Count > 0)
            {
                string cmd = Console.ReadLine();
                //string[] tokens = cmd.Split();
                //string action = tokens[0];
                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd.Contains("Add"))
                {
                    string song = cmd.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ",songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
