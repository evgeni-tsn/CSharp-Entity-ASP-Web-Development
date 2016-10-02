using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;
using _03.StudentsByFirstAndLastName;

namespace _05.SortStudents
{
    public class SortStudents
    {
        //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.Rewrite the same with LINQ query syntax.
        public static void Main()
        {
            var database = new StudentDirectory();

            var sortedStudents =
    database.Students.OrderByDescending(student => student.FirstName).ThenBy(student => student.LastName);

            var studentsSortQuery =
            from student in database.Students
            orderby student.FirstName descending,
            student.LastName descending
            select student;
            Console.WriteLine("Using Lambda");
            ByFirstAndLastName.PrintStudentInfo(sortedStudents);
            Console.WriteLine("Using Query");
            ByFirstAndLastName.PrintStudentInfo(studentsSortQuery);
        }
    }
}
