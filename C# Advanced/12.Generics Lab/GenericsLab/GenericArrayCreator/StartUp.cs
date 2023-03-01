using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[]nums = ArrayCreator.Create<int>(20, 3);
            string[] names = ArrayCreator.Create<string>(20, "asd");

        }
    }
}
