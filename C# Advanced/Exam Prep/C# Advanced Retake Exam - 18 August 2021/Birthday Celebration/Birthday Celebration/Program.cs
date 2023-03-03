using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guestCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wasteedFood = 0;

            while (guestCapacity.Count > 0 && plates.Count > 0)
            {
                int currGuest = guestCapacity.Peek();
                int currPlate = plates.Peek();

                if (currGuest == currPlate)
                {
                    guestCapacity.Dequeue();
                    plates.Pop();
                }
                else if (currGuest > currPlate)
                {
                    while (currGuest > 0)
                    {
                        if (plates.Count == 0)
                        {
                            break;
                        }
                        currPlate = plates.Pop();
                        currGuest -= currPlate;
                        if (currGuest < 0)
                        {
                            wasteedFood += -currGuest;
                        }
                    }
                    guestCapacity.Dequeue();
                }
                else
                {
                    wasteedFood += currPlate - currGuest;
                    guestCapacity.Dequeue();
                    plates.Pop();
                }
            }

            if (guestCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestCapacity)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {wasteedFood}");
        }
    }
}
