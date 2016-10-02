using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;
        private const string EmailRegex = @"(?<=\s|^)([A-Za-z0-9]*(?:[_.-][A-Za-z0-9]*)*@(?:[A-Za-z]*\-?[A-Za-z]*\.)*[A-Za-z]*\-?[A-Za-z]*)\b";

        public Person(string name, int age) : this(name, age, null)
        {
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length<0 || value.Length>100)
                {
                    throw new Exception("Name is not in range [0 - 100] characters");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Age is not in the range [0 - 100]");
                }

                this.age = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (value != null && !Regex.IsMatch(value, EmailRegex))
                {
                    throw new ArgumentException(@"Email should contain ""@""", "email");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nAge: {1} \nEmail: {2}", this.Name, this.Age, this.Email ?? "not set");
        }
    }
}
