using System;
using System.Collections.Generic;
using System.Linq;
using FootballLeague.Models;

namespace FootballLeague
{
    public static class LeagueManager
    {
        private static List<Team> allTeams = new List<Team>();
        private static List<Player> allPlayers = new List<Player>();
        private static List<Match> allMatches = new List<Match>();
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break; ;
                case "AddMatch":
                    AddMatch(inputArgs[2],inputArgs[3], int.Parse(inputArgs[4]), int.Parse(inputArgs[5]), int.Parse(inputArgs[1]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]), decimal.Parse(inputArgs[4]), inputArgs[5]);
                    break;
                case "ListTeam":
                    ListTeam();
                    break;
                case "ListPlayer":
                    ListPlayers();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
        }

        private static void ListPlayers()
        {
            foreach (var player in allPlayers)
            {
                Console.WriteLine(player);
            }
        }
        private static void ListMatches()
        {
            foreach (var match in allMatches)
            {
                Console.WriteLine(match);

            }
        }
        private static void ListTeam()
        {
            foreach (var team in allTeams)
            {
                Console.WriteLine(team);
            }
        }

        private static void AddTeam(string name, string nick, DateTime founded)
        {
            
            Team n = new Team(name, nick, founded);
            if (allTeams.Contains(n))
            {
                throw new ArgumentException("This team is already added.");
            }
            allTeams.Add(n);
        }
        private static List<int> idsList = new List<int>();
        private static void AddMatch(string hometeam, string awayteam, int scoreH,int scoreA, int id)
        {
            Score sc = new Score(scoreH, scoreA);
            var team1 = allTeams.FirstOrDefault(t => t.Name == hometeam);
            var team2 = allTeams.FirstOrDefault(t => t.Name == awayteam);
            Match m = new Match(team1,team2,sc,id);
            if (idsList.Contains(id))
            {
                throw new ArgumentException("Match with this ID is already added.");
            }
            allMatches.Add(m);
            idsList.Add(id);
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime bornDate, decimal salary, string teamName)
        {
            var team = allTeams.FirstOrDefault(t => t.Name == teamName);
            var player = new Player(firstName, lastName, salary, bornDate, team);
            allPlayers.Add(player);
        }
    }
}