using System;

namespace _06._Съединяване_на_текст_и_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname = Console.ReadLine();
            string secondName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            Console.WriteLine($"You are {firstname} {secondName}, a {age}-years old person from {town}.");
        }
    }
}
