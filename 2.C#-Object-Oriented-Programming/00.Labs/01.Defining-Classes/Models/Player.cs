using System;

namespace FootballLeague.Models
{
    public class Player
    {
        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime birthDate;
        private Team currTeam;

        private const int MinimumAllowedYear = 1980;

        public Player(string firstName, string lastName, decimal salary, DateTime birthDate, Team currTeam)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.BirthDate = birthDate;
            this.CurrTeam = currTeam;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name should be at least 3 characters long.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name should be at least 3 characters long.");
                }
                this.lastName = value;
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative.");
                }
                this.salary = value;
            }
        }
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set
            {
                if (value.Year < MinimumAllowedYear)
                {
                    throw new ArgumentException("Date of Birth’s year cannot be lower than "+MinimumAllowedYear);
                }
                this.birthDate = value;
            }
        }
        public Team CurrTeam
        {
            get { return currTeam; }
            set { currTeam = value; }
        }

        public override string ToString()
        {
            return $"Player: {firstName} {lastName} | BirthDate: {birthDate.ToShortDateString()} | Salary: {salary:F2} | Team: {currTeam}";
        }
    }
}