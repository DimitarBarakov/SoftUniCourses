﻿using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.Contains(key))
            {
                int index = text.IndexOf(key);
                text = text.Remove(index, key.Length);
            }
            Console.WriteLine(text);
        }
    }
}
