using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //List<IBuyer> buyers = new List<IBuyer>();
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen buyer = new Citizen(name, age, id, birthdate);
                    citizens.Add(buyer);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel buyer = new Rebel(name, age, group);
                    rebels.Add(buyer);
                }
            }

            int boughtFood = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (citizens.Any(c=>c.Name == cmd))
                {
                    boughtFood += 10;
                }
                else if (rebels.Any(r => r.Name == cmd))
                {
                    boughtFood += 5;
                }
            }
            Console.WriteLine(boughtFood);
        }
    }
}
