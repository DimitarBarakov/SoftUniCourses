using System;

namespace Задача_6._Висок_скок
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int high = target - 30;
            int jumps = 0;
            while (high < target)
            {
                for (int i = 1; i <= 3; i++)
                {
                    int jumpTry = int.Parse(Console.ReadLine());
                    if (jumpTry > high)
                    {
                        high += 5;
                        jumps++;
                        break;
                    }
                    else
                    {
                        jumps++;
                        if (i == 3)
                        {
                            Console.WriteLine($"Tihomir failed at {high}cm after {jumps} jumps.");
                            return;
                        }
                    }
                }
            }
            for (int i = 1; i <= 3; i++)
            {
                int jumpTry = int.Parse(Console.ReadLine());
                if (jumpTry > high)
                {
                    high += 5;
                    jumps++;
                    break;
                }
                else
                {
                    jumps++;
                    if (i == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {high}cm after {jumps} jumps.");
                        return;
                    }
                }
            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {target}cm after {jumps} jumps.");
        }
    }
}
