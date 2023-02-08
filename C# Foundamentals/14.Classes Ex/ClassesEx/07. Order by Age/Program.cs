using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();
                Person person = new Person();
                person.Name = info[0];
                person.Id = info[1];
                person.Age = int.Parse(info[2]);
                if (people.Any(p => p.Id == person.Id))
                {
                    people.FirstOrDefault(p => p.Id == person.Id).Age = person.Age;
                    people.FirstOrDefault(p => p.Id == person.Id).Name = person.Name;
                }
                else
                {
                    people.Add(person);
                }
            }
            List<Person> orderedByAge = people.OrderBy(p => p.Age).ToList();
            foreach (Person p in orderedByAge)
            {
                Console.WriteLine($"{p.Name} with ID: {p.Id} is {p.Age} years old.");
            }
        }
    }
}
