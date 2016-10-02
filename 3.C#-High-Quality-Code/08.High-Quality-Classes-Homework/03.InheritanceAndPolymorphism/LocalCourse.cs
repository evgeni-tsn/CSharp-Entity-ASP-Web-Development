namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string name)
            : base(name)
        {
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
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
