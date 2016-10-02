using System;

namespace _04.SoftwareUniversityLearningSystem
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("First name can't be null or empty.");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Last name can't be null or empty.");
                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Age should be in range [1..100].");
                }
                this.age = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1} -> {2} years old.",this.FirstName,this.LastName,this.Age);
        }
    }

    public class Person1
    {
    }
}