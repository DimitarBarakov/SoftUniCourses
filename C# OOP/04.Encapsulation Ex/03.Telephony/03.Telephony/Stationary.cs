using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Stationary : IPhone
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
