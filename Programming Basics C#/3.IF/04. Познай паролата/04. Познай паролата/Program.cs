using System;

namespace _04._Познай_паролата
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            if (phrase=="s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
