using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Browsing(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
