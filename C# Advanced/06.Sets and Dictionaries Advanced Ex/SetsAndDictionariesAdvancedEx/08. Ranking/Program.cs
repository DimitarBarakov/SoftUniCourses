using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> contestsAndPassword = new Dictionary<string,string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = cmd.Split(':');
                string contest = tokens[0];
                string password = tokens[1];
                contestsAndPassword.Add(contest, password);
            }

            string cmd1;
            Dictionary<string,Dictionary<string,int>> usernamesAndContest = new Dictionary<string,Dictionary<string, int>>();
            while ((cmd1 = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = cmd1.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestsAndPassword.ContainsKey(contest) && contestsAndPassword[contest] == password)
                {
                    if (usernamesAndContest.ContainsKey(username))
                    {
                        if (usernamesAndContest[username].ContainsKey(contest))
                        {
                            if (usernamesAndContest[username][contest] < points)
                            {
                                usernamesAndContest[username][contest] = points;
                            }
                        }
                        else
                        {
                            usernamesAndContest[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        usernamesAndContest.Add(username, new Dictionary<string, int>());
                        usernamesAndContest[username].Add(contest, points);
                    }
                }
            }

            int maxPoints = 0;
            string bestStudent = "";
            foreach (var item in usernamesAndContest)
            {
                int currPoints = 0;
                foreach (var contest in item.Value)
                {
                    currPoints += contest.Value;
                }
                if (currPoints>maxPoints)
                {
                    maxPoints = currPoints;
                    bestStudent = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestStudent} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            usernamesAndContest = usernamesAndContest.OrderBy(name => name.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var username in usernamesAndContest)
            {
                Console.WriteLine(username.Key);
                var orderedContestsByPoints = username.Value.OrderByDescending(x => x.Value).ToDictionary(n => n.Key, n => n.Value);
                foreach (var contest in orderedContestsByPoints)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
