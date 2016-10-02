using System;

namespace _01.HumanStudentAndWorker.Humans
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "weekSalary", "Week salary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException(
                        "workHoursPerDay", "Work hours per day should be in the range [0 ... 24].");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.workHoursPerDay == 0)
            {
                return 0;
            }

            double workHoursPerWeek = 5 * this.WorkHoursPerDay;
            decimal hourSalary = this.WeekSalary / (decimal)workHoursPerWeek;

            return hourSalary;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format(
                $"\nWeek salary: {this.weekSalary}\n" +
                $"Work hours per day: {this.workHoursPerDay}\n" +
                $"Hourly salary: {this.MoneyPerHour():F2}\n");

            return result;
        }
    }
}