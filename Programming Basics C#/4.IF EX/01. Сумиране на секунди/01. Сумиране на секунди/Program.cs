using System;

namespace _01._Сумиране_на_секунди
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int timeInSecs = firstTime + secondTime + thirdTime;
            int minutes = timeInSecs / 60;
            int secs = timeInSecs % 60;
            if (secs<10)
            {
                Console.WriteLine($"{minutes}:0{secs}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{secs}");
            }
            
        }
    }
}
