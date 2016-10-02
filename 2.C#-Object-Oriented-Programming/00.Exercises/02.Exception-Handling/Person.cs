using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValidPerson
{
    class Person
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
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        value,
                        "The first name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        value,
                        "The first name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value<0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "Age should be in range ");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format(firstName+" "+lastName + " -> " + age);
        }
    }
}
