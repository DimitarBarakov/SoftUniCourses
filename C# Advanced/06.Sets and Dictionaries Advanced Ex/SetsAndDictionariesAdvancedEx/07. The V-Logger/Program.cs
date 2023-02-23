using System;
using System.Collections.Generic;

namespace _07._The_V_Logger
{
    class Vlogger
    {
        string name;
        List<string> followers;
        int followings;
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public int Followings { get; set; }

        public Vlogger(string name, List<int> followers, int followings)
        {
            this.Name = name;
            this.Followers = Followers;
            this.Followings = followings;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string,Vlogger>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = cmd.Split();
                string action = tokens[1];
                if (action == "joined")
                {
                    string vloggerName = tokens[0];
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        

                    }
                }
            }
        }
    }
}
