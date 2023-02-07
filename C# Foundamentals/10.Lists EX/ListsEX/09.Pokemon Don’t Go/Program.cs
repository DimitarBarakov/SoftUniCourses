using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int removedElementsSum = 0;
            while (pokemons.Count>0)
            {
                
                int index = int.Parse(Console.ReadLine());
                int removedElement;
                if (index < 0)
                {
                    index = 0;
                    removedElement = pokemons[index];
                    removedElementsSum += removedElement;
                    pokemons[index] = pokemons[pokemons.Count - 1];
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (removedElement >= pokemons[i])
                        {
                            pokemons[i] += removedElement;
                        }
                        else
                        {
                            pokemons[i] += removedElement;
                        }
                    }
                }
                else if (index >= pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    removedElement = pokemons[index];
                    removedElementsSum += removedElement;
                    pokemons[index] = pokemons[0];
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (removedElement >= pokemons[i])
                        {
                            pokemons[i] += removedElement;
                        }
                        else
                        {
                            pokemons[i] += removedElement;
                        }
                    }
                }
                else
                {
                    removedElement = pokemons[index];
                    removedElementsSum += removedElement;
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (removedElement >= pokemons[i])
                        {
                            pokemons[i] += removedElement;
                        }
                        else
                        {
                            pokemons[i] -= removedElement;
                        }
                    }
                }
            }
            Console.WriteLine(removedElementsSum);
        }
    }
}
