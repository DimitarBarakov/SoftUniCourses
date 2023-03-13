using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string res = spy.CollectSettersAndGetters("Stealer.Hacker");
            Console.WriteLine(res);
        }
    }
}
