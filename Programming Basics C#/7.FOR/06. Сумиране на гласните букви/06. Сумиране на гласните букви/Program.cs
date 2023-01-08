using System;

namespace _06._Сумиране_на_гласните_букви
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter=='a')
                {
                    sum += 1;
                }
                if (letter == 'e')
                {
                    sum += 2;
                }
                if (letter == 'o')
                {
                    sum += 4;
                }
                if (letter == 'u')
                {
                    sum += 5;
                }
                if (letter == 'i')
                {
                    sum += 3;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
