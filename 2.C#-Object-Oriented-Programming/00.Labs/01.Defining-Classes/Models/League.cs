using System;
using System.Collections.Generic;

namespace FootballLeague.Models
{
    static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();
      
        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        } 
    }
}
