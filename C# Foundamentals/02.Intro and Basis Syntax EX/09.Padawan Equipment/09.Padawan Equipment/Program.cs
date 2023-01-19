using System;

namespace _09.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            double countOfStudents = double.Parse(Console.ReadLine());
            double pricePerSaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());
            double freeBelts = 0;
            if (countOfStudents >= 6)
            {
                freeBelts = countOfStudents * 1.0 / 6;
            }
            double sabersCount = Math.Ceiling(countOfStudents * 1.1);
            double priceForAllSabers = sabersCount * pricePerSaber;
            double priceForAllBelts = (countOfStudents - freeBelts) * pricePerBelt;
            double priceForAllRobes = countOfStudents * pricePerRobe;
            double totalPrice = priceForAllBelts + priceForAllRobes + priceForAllSabers;
            if (totalPrice <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - amountOfMoney:f2}lv more.");
            }
        }
    }
}
