using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            this.Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double PriceForBox { get; set; }    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command;
            while ((command = Console.ReadLine())!="end")
            {
                string[] tokens = command.Split(' ');
                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                double itemPrice = double.Parse(tokens[3]);

                Box newBox = new Box();
                newBox.SerialNumber = serialNumber;
                newBox.Item.Name = itemName;
                newBox.Item.Price = itemPrice;
                newBox.Quantity = itemQuantity;
                newBox.PriceForBox = itemQuantity * itemPrice;

                boxes.Add(newBox);
            }
            List<Box> sortedBoxes = boxes.OrderByDescending(box => box.PriceForBox).ToList();
            for (int i = 0; i < sortedBoxes.Count; i++)
            {
                Box currentBox = sortedBoxes[i];
                Console.WriteLine(currentBox.SerialNumber);
                Console.WriteLine($"-- {currentBox.Item.Name} - ${currentBox.Item.Price:f2}: {currentBox.Quantity}");
                Console.WriteLine($"-- ${currentBox.PriceForBox:f2}");

            }
        }
    }
}
