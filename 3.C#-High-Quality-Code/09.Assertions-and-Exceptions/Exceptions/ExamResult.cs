namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade cannot be negative");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minGrade), "Minimal grade cannot be negative");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException(nameof(maxGrade), "Max grade should be greater than Min grade");
            }

            if (string.IsNullOrEmpty(comments))
            {
                throw new ArgumentException("Comments cannot be empty");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}
