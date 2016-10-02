using System;

namespace FootballLeague.Models
{
    class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        public Match(Team homeTeam, Team awayTeam, Score score, int id)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.Id = id;
        }

        public Team HomeTeam
        {
            get { return this.homeTeam; }
            set
            {
                //TODO throw exception for equal teams
                this.homeTeam = value;
            }
        }
        public Team AwayTeam
        {
            get { return this.awayTeam; }
            set
            {
                //TODO throw exception for equal teams
                this.awayTeam = value;
            }
        }
        public Score Score
        {
            get { return score; }
            set { score = value; }
        }
        public int Id
        {
            get { return this.id; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Id number must be positive.");
                }
                this.id = value;
            }
        }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.HomeTeam : this.AwayTeam;
        }
        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.AwayTeamGoals;
        }

        public override string ToString()
        {
            //29 Southampton WestHamUnited 3 2
            return string.Format($"{id:00}: {homeTeam} ---VS--- {awayTeam} ");
        }
    }
}
