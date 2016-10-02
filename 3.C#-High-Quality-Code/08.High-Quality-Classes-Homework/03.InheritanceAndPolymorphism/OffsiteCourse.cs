namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name) 
            : base(name)
        {
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName) : base(courseName, teacherName)
        {
            this.Students = new List<string>();
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }

        protected override string GetStudentsAsString()
        {
            if ((this.Students == null) || (this.Students.Count == 0))
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}
