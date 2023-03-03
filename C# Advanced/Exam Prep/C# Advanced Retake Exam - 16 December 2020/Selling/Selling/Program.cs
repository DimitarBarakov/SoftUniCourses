using System;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n,n];

            int myRow = 0;
            int myCol = 0;
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                char[] els = line.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    bakery[row,col] = els[col];
                    if (bakery[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }
            int collectedMoney = 0;
            
            while (true)
            {
                bakery[myRow, myCol] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up": myRow--;break;
                    case "down": myRow++; break;
                    case "left": myCol--; break;
                    case "right": myCol++; break;
                    default:
                        break;
                }
                if ((myRow == -1)||(myRow == n)||(myCol == -1)||(myCol == n))
                {
                    break;
                }
                else
                {
                    if (char.IsDigit(bakery[myRow, myCol]))
                    {
                        collectedMoney += bakery[myRow, myCol] - '0';
                        bakery[myRow, myCol] = 'S';
                        if (collectedMoney >= 50)
                        {
                            break;
                        }
                    }
                    else if (bakery[myRow, myCol] == 'O')
                    {
                        bakery[myRow, myCol] = '-';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (bakery[row, col] == 'O')
                                {
                                    myRow = row;
                                    myCol = col;
                                    bakery[myRow, myCol] = 'S';
                                }
                            }
                        }
                    }
                }
            }

            if (collectedMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {collectedMoney}");
            for (int row = 0; row < n; row++)
            {
                string line = "";
                for (int col = 0; col < n; col++)
                {
                    line += bakery[row, col];
                }
                Console.WriteLine(line);
            }
        }
    }
}
