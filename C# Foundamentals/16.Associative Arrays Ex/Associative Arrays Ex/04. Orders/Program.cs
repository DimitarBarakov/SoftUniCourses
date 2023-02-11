using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Product
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> productAndCount = new Dictionary<string, List<double>>();
            //Dictionary<string, double> productAndTotalPrice = new Dictionary<string, double>();
            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] product = command.Split();

                //Product currentProduct = new Product();
                //currentProduct.Name = product[0];
                //currentProduct.Price = double.Parse(product[1]);
                //currentProduct.Count = int.Parse(product[2]);
                string name = product[0];
                double price = double.Parse(product[1]);
                double count = double.Parse(product[2]);
                if (productAndCount.ContainsKey(name))
                {
                    productAndCount[name][0] += count;
                    productAndCount[name][1] = price;
                }
                else
                {
                    productAndCount.Add(name, new List<double> {count, price});
                }
            }
            foreach (var item in productAndCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }
        }
    }
}
