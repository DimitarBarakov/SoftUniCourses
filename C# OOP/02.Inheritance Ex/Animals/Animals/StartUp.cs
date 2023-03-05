using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];
                if (type == "Dog")
                {

                }
            }
        }
    }
}
