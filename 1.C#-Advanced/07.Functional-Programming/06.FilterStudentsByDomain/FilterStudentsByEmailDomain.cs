using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;
using _03.StudentsByFirstAndLastName;

namespace _06.FilterStudentsByDomain
{
    class FilterStudentsByEmailDomain
    {
        //Print all students that have email @abv.bg. Use LINQ.
        static void Main()
        {
            var database = new StudentDirectory();

            var getAllValidMails =
                from student in database.Students
                where student.Email.Substring(student.Email.Length - 6) == "abv.bg"
                select student;

            ByFirstAndLastName.PrintStudentInfo(getAllValidMails);
        }
    }
}
