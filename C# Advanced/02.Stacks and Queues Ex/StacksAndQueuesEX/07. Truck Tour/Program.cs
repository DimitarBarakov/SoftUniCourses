using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class PetrolPump
    {
        public int ID { get; set; }
        public int Petrol { get; set; }
        public int Distance { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();
            int myPetrol = 0;
            for (int i = 1; i <= n; i++)
            {
                int[] arg = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int pertol = arg[0];
                int distance = arg[1];
                PetrolPump petrolPump = new PetrolPump();
                petrolPump.Petrol = pertol;
                petrolPump.Distance = distance;
                petrolPump.ID = i;
                pumps.Enqueue(petrolPump);
            }
            int startingPump = 0;
            for (int i = 1; i <= n; i++)
            {
                myPetrol += pumps.Peek().Petrol;
                if (myPetrol < pumps.Peek().Distance)
                {
                    PetrolPump temp = pumps.Dequeue();
                    pumps.Enqueue(temp);
                    i = 1;
                    startingPump++;
                }
                else
                {
                    myPetrol-=pumps.Dequeue().Distance;
                }
            }
            Console.WriteLine(startingPump);
        }
    }
}
