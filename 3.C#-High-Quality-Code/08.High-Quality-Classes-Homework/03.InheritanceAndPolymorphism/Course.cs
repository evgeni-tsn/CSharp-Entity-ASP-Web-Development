namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public abstract class Course
    {
        private string name;

        private string teacherName;

        private IList<string> students; 

        protected Course(string name)
        {
            this.Name = name;
        }

        protected Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
        }

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Teacher name cannot be null or empty");
                }
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get { return this.students; }

            set
            {
                if (value.Count < 0)
                {
                    throw new IndexOutOfRangeException("Students list cannot be negative.");
                }
                this.students = value;
            }

        }

        protected abstract string GetStudentsAsString();
    }
}