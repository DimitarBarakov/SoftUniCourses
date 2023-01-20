using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int temp = pokemonPower;
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int count = 0;
            while (pokemonPower >= distanceBetweenTargets)
            {
                
                pokemonPower -= distanceBetweenTargets;
                count++;
                if (pokemonPower == temp*1.0 / 2 && exhaustionFactor > 0)
                {

                    pokemonPower /= exhaustionFactor;

                }
            }
            Console.WriteLine(pokemonPower);
            Console.WriteLine(count);
        }
    }
}
