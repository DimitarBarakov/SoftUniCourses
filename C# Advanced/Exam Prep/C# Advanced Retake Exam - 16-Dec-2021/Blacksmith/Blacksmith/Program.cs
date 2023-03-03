using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);

            int forgedSwordsCount = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int steelPortion = steel.Peek();
                int carbonPortion = carbon.Peek();
                int sum = steelPortion + carbonPortion;

                switch (sum)
                {
                    case 70: swords["Gladius"]++; steel.Dequeue(); carbon.Pop(); forgedSwordsCount++; break;
                    case 80: swords["Shamshir"]++; steel.Dequeue(); carbon.Pop(); forgedSwordsCount++; break;
                    case 90: swords["Katana"]++; steel.Dequeue(); carbon.Pop(); forgedSwordsCount++; break;
                    case 110: swords["Sabre"]++; steel.Dequeue(); carbon.Pop(); forgedSwordsCount++; break;
                    case 150: swords["Broadsword"]++; steel.Dequeue(); carbon.Pop(); forgedSwordsCount++; break;
                    default:
                        steel.Dequeue();
                        carbonPortion += 5;
                        carbon.Pop();
                        carbon.Push(carbonPortion);
                        break;
                }
            }
            var forgedSwords = swords.Where(s => s.Value > 0).OrderBy(s=>s.Key);
            if (forgedSwordsCount > 0)
            {
                Console.WriteLine($"You have forged {forgedSwordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var sword in forgedSwords)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
