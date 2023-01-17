using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string comm = Console.ReadLine();
            double myMoney = 0;
            while (comm != "Start")
            {
                double money = double.Parse(comm);
                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    myMoney += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
                comm = Console.ReadLine();
            }
            comm = Console.ReadLine();
            while (comm != "End")
            {
                if (comm == "Nuts")
                {
                    if (myMoney - 2 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        myMoney -= 2;
                        Console.WriteLine($"Purchased nuts");
                    }
                    
                }
                else if (comm == "Water")
                {
                    if (myMoney - 0.7 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        myMoney -= 0.7;
                        Console.WriteLine($"Purchased water");
                    }
                }
                else if (comm == "Crisps")
                {
                    if (myMoney - 1.5 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        myMoney -= 1.5;
                        Console.WriteLine($"Purchased crisps");
                    }
                }
                else if (comm == "Soda")
                {
                    if (myMoney - 0.8 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        myMoney -= 0.8;
                        Console.WriteLine($"Purchased soda");
                    }
                }
                else if (comm == "Coke")
                {
                    if (myMoney - 1 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        myMoney -= 1;
                        Console.WriteLine($"Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                comm = Console.ReadLine();
            }
            Console.WriteLine($"Change: {myMoney:f2}");
        }
    }
}
