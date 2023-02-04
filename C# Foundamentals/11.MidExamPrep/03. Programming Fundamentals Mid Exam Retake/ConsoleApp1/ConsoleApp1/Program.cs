using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            int shotTargetsCount = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int indexToShoot = int.Parse(command);
                if (indexToShoot < 0 || indexToShoot >= targets.Count)
                {
                    continue;
                }
                else
                {
                    if (targets[indexToShoot] == -1)
                    {
                        continue;
                    }
                    else
                    {
                        shotTargetsCount++;
                        int value = targets[indexToShoot];
                        targets[indexToShoot] = -1;
                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (targets[i] > value && targets[i] != -1)
                            {
                                targets[i] -= value;
                            }
                            else if (targets[i] <= value && targets[i] != -1)
                            {
                                targets[i] += value;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Shot targets: {shotTargetsCount} -> {string.Join(' ', targets)}");
        }
    }
}
