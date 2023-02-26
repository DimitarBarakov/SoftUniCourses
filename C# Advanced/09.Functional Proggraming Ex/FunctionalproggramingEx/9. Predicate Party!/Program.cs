using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


            List<string> names = Console.ReadLine().Split().ToList();
            string cmd;
           
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                
                string[] tokens = cmd.Split();
                string action = tokens[0];
                string condition = tokens[1];
                string arg = tokens[2];
                Predicate<string> predicate = GetPredicate(condition, arg);
                if (action == "Remove")
                {
                    //string condition = tokens[1];
                    //if (condition == "StartsWith")
                    //{
                    //    string s = tokens[2];
                    //    names.RemoveAll(x => x.StartsWith(s));
                    //}
                    //else if (condition == "EndsWith")
                    //{
                    //    string s = tokens[2];
                    //    names.RemoveAll(x => x.EndsWith(s));
                    //}
                    //else
                    //{
                    //    int length = int.Parse(tokens[2]);
                    //    names.RemoveAll(x => x.Length == length);
                    //}
                    names.RemoveAll(predicate);
                }
                else
                {
                    //string condition = tokens[1];
                    //if (condition == "StartsWith")
                    //{
                    //    string s = tokens[2];
                        foreach (string name in names)
                        {
                            if (predicate(name))
                            {
                                names.Insert(names.IndexOf(name) + 1, name);
                            }
                        }
                    //}
                    //else if (condition == "EndsWith")
                    //{
                    //    string s = tokens[2];
                    //    foreach (string name in names)
                    //    {
                    //        if (name.EndsWith(s))
                    //        {
                    //            names.Insert(names.IndexOf(name) + 1, name);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    int length = int.Parse(tokens[2]);
                    //    foreach (string name in names)
                    //    {
                    //        if (name.Length == length)
                    //        {
                    //            names.Insert(names.IndexOf(name) + 1, name);
                    //        }
                    //    }
                    //}
                }
                
            }
            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", args) + " are going to the party!");
            }
        }

        public static Predicate<string> GetPredicate(string command, string arg)
        {
            if (command == "StartsWith")
            {
                return x => x.StartsWith(arg);
            }
            else if (command == "EndsWith")
            {
                return x => x.EndsWith(arg);
            }
            else
            {
                return x => x.Length == int.Parse(arg);
            }
        }
    }
}
