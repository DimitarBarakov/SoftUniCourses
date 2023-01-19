using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();
            double pricePerPerson = 0;

            if (day == "Friday")
            {
                if (typeOfPeople == "Students")
                {
                    pricePerPerson = 8.45;
                }
                else if (typeOfPeople == "Business")
                {
                    pricePerPerson = 10.90;
                }
                else if (typeOfPeople == "Regular")
                {
                    pricePerPerson = 15;
                }
            }
            else if (day == "Saturday")
            {
                if (typeOfPeople == "Students")
                {
                    pricePerPerson = 9.80;
                }
                else if (typeOfPeople == "Business")
                {
                    pricePerPerson = 15.60;
                }
                else if (typeOfPeople == "Regular")
                {
                    pricePerPerson = 20;
                }
            }
            if (day == "Sunday")
            {
                if (typeOfPeople == "Students")
                {
                    pricePerPerson = 10.46;
                }
                else if (typeOfPeople == "Business")
                {
                    pricePerPerson = 16;
                }
                else if (typeOfPeople == "Regular")
                {
                    pricePerPerson = 22.50;
                }
            }
            double total = count * pricePerPerson;
            if (typeOfPeople == "Students" && count >= 30)
            {
                total *= 0.85;
            }
            else if (typeOfPeople == "Business" && count >= 100)
            {
                total -= 10 * pricePerPerson;
            }
            else if (typeOfPeople == "Regular" && count >= 10 && count <= 20)
            {
                total *= 0.95;
            }
            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
