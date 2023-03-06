using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                string[] namesAndMoney = Console.ReadLine().Split(';').ToArray();
                foreach (var item in namesAndMoney)
                {
                    string[] splitted = item.Split('=');
                    string name = splitted[0];
                    decimal money = decimal.Parse(splitted[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] productsAndCost = Console.ReadLine().Split(';').ToArray();
                foreach (var item in productsAndCost)
                {
                    string[] splitted = item.Split('=');
                    string productName = splitted[0];
                    decimal cost = decimal.Parse(splitted[1]);
                    Product product = new Product(productName, cost);
                    products.Add(product);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] tokens = cmd.Split(' ');
                string personName = tokens[0];
                string productName = tokens[1];

                Person currPerson = people.First(p => p.Name == personName);
                Product currProduct = products.First(p => p.Name == productName);
                if (currPerson.Money >= currProduct.Cost)
                {
                    Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                    currPerson.Money -= currProduct.Cost;
                    currPerson.Products.Add(currProduct);
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
