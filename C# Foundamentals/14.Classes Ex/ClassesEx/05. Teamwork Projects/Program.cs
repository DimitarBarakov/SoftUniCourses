using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string commnd = Console.ReadLine();
                string[] tokens = commnd.Split('-');
                string crator = tokens[0];
                string teamName = tokens[1];

                Team newTeam = new Team();
                newTeam.Creator = crator;   
                newTeam.Name = teamName;

                if (IsCreatorExist(teams, newTeam.Creator))
                {
                    Console.WriteLine($"{newTeam.Creator} cannot create another team!");
                }
                else
                {
                    if (IsTeamExist(teams, newTeam.Name))
                    {
                        Console.WriteLine($"Team {newTeam.Name} was already created!");
                    }
                    else
                    {
                        teams.Add(newTeam);
                        Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Creator}!");
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] tokens = command.Split("->");
                string user = tokens[0];
                string teamName = tokens[1];

                if (IsUserInAnitherTeam(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    if (IsTeamExist(teams, teamName))
                    {
                        for (int i = 0; i < teams.Count; i++)
                        {
                            if (teams[i].Name == teamName)
                            {
                                teams[i].Members.Add(user);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                    }
                }
            }

            List<Team> teamsToDisband  = new List<Team>();
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    teamsToDisband.Add(teams[i]);
                }
            }
            List<Team> orderedDisbandTeams = teamsToDisband.OrderBy(x => x.Name).ToList();
            teams.RemoveAll(team => team.Members.Count == 0);

            List<Team> orderedTeams = teams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name).ToList();
            for (int i = 0; i < orderedTeams.Count; i++)
            {
                Team currentTeam = orderedTeams[i];
                Console.WriteLine($"{currentTeam.Name}");
                Console.WriteLine($"- {currentTeam.Creator}");
                currentTeam.Members.Sort();
                for (int j = 0; j < currentTeam.Members.Count; j++)
                {
                    Console.WriteLine($"-- {currentTeam.Members[j]}");
                }
            }

            Console.WriteLine("Teams to disband:");
            for (int i = 0; i < orderedDisbandTeams.Count; i++)
            {
                Console.WriteLine(orderedDisbandTeams[i].Name);
            }
        }

        static bool IsTeamExist(List<Team> teams, string name)
        {
            bool IsTeamExist = false;
            for (int j = 0; j < teams.Count; j++)
            {
                Team currentTeam = teams[j];
                if (currentTeam.Name == name)
                {
                    IsTeamExist = true;
                    break;
                }
            }
            return IsTeamExist;
        }

        static bool IsCreatorExist(List<Team> teams, string creator)
        {
            bool isCreatorExist = false;
            for (int j = 0; j < teams.Count; j++)
            {
                Team currentTeam = teams[j];
                if (currentTeam.Creator == creator)
                {
                    isCreatorExist = true;
                    break;
                }
            }
            return isCreatorExist;
        }

        static bool IsUserInAnitherTeam(List<Team> teams, string user)
        {
            bool isUserInAnitherTeam = false;
            for (int i = 0; i < teams.Count; i++)
            {
                Team currentTeam = teams[i];
                if (currentTeam.Members.Contains(user) || currentTeam.Creator == user)
                {
                    isUserInAnitherTeam = true;
                    break;
                }
            }
            return isUserInAnitherTeam;
        }
    }
}
