namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Last name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException(nameof(this.Exams), "Exams cannot be null");
            }

            if (this.Exams.Count == 0)
            {
                Console.WriteLine("The student has no exams!");
            }

            return this.Exams.Select(t => t.Check()).ToList();
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null)
            {
                throw new ArithmeticException("Cannot calculate average on missing exams");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArithmeticException("Cannot calculate average on 0 exams");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();

            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = 
                    ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}
