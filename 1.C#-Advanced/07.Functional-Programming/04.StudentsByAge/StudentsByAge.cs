using System;
using System.Collections.Generic;
using System.Linq;
using _01.ClassStudent;

namespace _04.StudentsByAge
{
    class StudentsByAge
    {
        //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. The query should return only the first name, last name and age.
        static void Main()
        {
            var database = new StudentDirectory();

            var getByAge =
                from student in database.Students
                where student.Age > 17 && student.Age < 25
                select new { student.FirstName, student.LastName, student.Age };

            foreach (var student in getByAge)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}",
                                    student.FirstName, student.LastName, student.Age);
            }
        }
    }
}

