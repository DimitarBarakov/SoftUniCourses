using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            
            //if (peopleCount<=elevatorCapacity)
            //{
            //    Console.WriteLine(1);
            //}
            //else
            //{
                int courses = peopleCount / elevatorCapacity;
                if (peopleCount%elevatorCapacity==0)
                {
                    Console.WriteLine(courses);
                }
                else
                {
                    Console.WriteLine(courses + 1);
                }
                
            //}
            
        }
    }
}
