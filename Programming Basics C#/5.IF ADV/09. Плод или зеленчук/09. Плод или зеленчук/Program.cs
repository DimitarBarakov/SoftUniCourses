using System;

namespace _09._Плод_или_зеленчук
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            switch (product)
            {
                case "banana":
                case "kiwi":
                case "apple":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit"); break;
                case "tomato":
                case "cucumber":
                case "carrot":
                case "pepper":
                    Console.WriteLine("vegetable"); break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
