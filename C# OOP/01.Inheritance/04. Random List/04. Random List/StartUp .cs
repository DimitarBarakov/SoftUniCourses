using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList() { "1", "2", "3" };
            Console.WriteLine(rndList.RandomString());
            Console.WriteLine(String.Join(" ", rndList));
        }
    }
}
