using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> areEqual = new EqualityScale<int>(1, 1);
            Console.WriteLine(areEqual.AreEqual());
        }
    }
}
