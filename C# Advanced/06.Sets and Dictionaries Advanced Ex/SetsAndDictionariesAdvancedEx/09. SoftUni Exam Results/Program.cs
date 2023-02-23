using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> userAndPoints = new Dictionary<string, int>();
            Dictionary<string, int> languageAndSubmissions = new Dictionary<string, int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = cmd.Split('-');
                string action = tokens[1];
                string user = tokens[0];
                if (action == "banned")
                {
                    userAndPoints.Remove(user);
                }
                else
                {
                    string language = action;
                    int points = int.Parse(tokens[2]);

                    if (userAndPoints.ContainsKey(user))
                    {
                        if (userAndPoints[user] < points)
                        {
                            userAndPoints[user] = points;
                        }
                    }
                    else
                    {
                        userAndPoints.Add(user, points);
                    }


                    if (languageAndSubmissions.ContainsKey(language))
                    {
                        languageAndSubmissions[language]++;
                    }
                    else
                    {
                        languageAndSubmissions.Add(language, 1);
                    }
                }
            }

            userAndPoints = userAndPoints.OrderByDescending(u => u.Value).ThenBy(u => u.Key).ToDictionary(u => u.Key, u => u.Value);
            Console.WriteLine("Results:");
            foreach (var user in userAndPoints)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            languageAndSubmissions = languageAndSubmissions.OrderByDescending(l => l.Value).ThenBy(l => l.Key).ToDictionary(l => l.Key, l => l.Value);
            Console.WriteLine("Submissions:");
            foreach (var language in languageAndSubmissions)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
