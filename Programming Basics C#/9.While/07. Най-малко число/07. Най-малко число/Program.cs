using System;

namespace _07._Най_малко_число
{
    class Program
    {
        static void Main(string[] args)
        {
            
                string comm = Console.ReadLine();
                int min = int.MaxValue;
                while (comm != "Stop")
                {
                    int num = int.Parse(comm);
                    if (num < min)
                    {
                        min = num;
                    }
                    comm = Console.ReadLine();
                }
                Console.WriteLine(min);
            }
        }
    }
