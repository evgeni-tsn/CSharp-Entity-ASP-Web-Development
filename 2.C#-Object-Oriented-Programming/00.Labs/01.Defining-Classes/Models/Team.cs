using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Models
{
    public class Team
    {
        public const int MinimumAllowedYear = 1850;

        private string name;
        private string nickname;
        private DateTime founded;
        private List<Player> players;

        public Team(string name, string nickname, DateTime founded)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.Founded = founded;
            this.players = new List<Player>();
        }
        

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should be at least 5 characters long.");
                }
                this.name = value;
            }
        }
        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nickname should be at least characters long.");
                }
                this.nickname = value;
            }
        }
        public DateTime Founded
        {
            get { return this.founded; }
            set
            {
                if (value.Year < MinimumAllowedYear)
                {
                    throw new ArgumentException("Year of foundation cannot be lower than " + MinimumAllowedYear);
                }
                this.founded = value;
            }
        }
        public List<Player> Players
        {
            get { return this.players; }
        }

        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExist(player))
            {
                throw new InvalidOperationException("Player already exist for that team");
            }
            this.players.Add(player);
        }
        private bool CheckIfPlayerExist(Player player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
        }

        public override string ToString()
        {
            return $"{name,-15} --> {nickname,-15} | Founded: {founded.Year,-15}";
        }
    }
}