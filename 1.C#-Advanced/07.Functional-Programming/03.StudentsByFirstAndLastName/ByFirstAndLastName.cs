using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;

namespace _03.StudentsByFirstAndLastName
{
    public class ByFirstAndLastName
    {
        //Print all students whose first name is before their last name alphabetically. Use a LINQ query.
        public static void Main()
        {
            var database = new StudentDirectory();

            var groupByFirstLastName = 
                from student in database.Students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            PrintStudentInfo(groupByFirstLastName);
        }
        public static void PrintStudentInfo(IEnumerable<Student> studentsQuery)
        {
                foreach (var student in studentsQuery)
                {
                    Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);

                    Console.WriteLine("Age: {0}, Faculty Number: {1} ", student.Age, student.FacultyNumber);
                    Console.WriteLine("Phone: {0}", student.Phone);
                    Console.WriteLine("Email: {0}", student.Email);
                    Console.WriteLine("Grades: {{{0}}}", string.Join(", ", student.Marks));
                    Console.WriteLine();
                }
            }
        }
    }
