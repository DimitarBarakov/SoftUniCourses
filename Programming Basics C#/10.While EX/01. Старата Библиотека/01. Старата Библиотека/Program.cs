using System;

namespace _01._Старата_Библиотека
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            string checkingBook = Console.ReadLine();
            int count = 0;
            while (checkingBook != "No More Books")
            {
                if (checkingBook==searchedBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    return;
                }
                count++;
                checkingBook = Console.ReadLine();
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {count} books.");
        }
    }
}
