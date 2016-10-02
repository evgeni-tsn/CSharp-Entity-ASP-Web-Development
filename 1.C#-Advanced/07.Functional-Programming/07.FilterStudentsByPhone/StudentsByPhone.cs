using System;
using System.Linq;
using System.Text.RegularExpressions;
using _01.ClassStudent;
using _03.StudentsByFirstAndLastName;

class StudentsByPhone
{
    //Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.
    static void Main()
    {
        var database = new StudentDirectory();

        var groupByPhone =
            from student in database.Students
            where
                student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") ||
                student.Phone.StartsWith("+359 2")
            select student;

        ByFirstAndLastName.PrintStudentInfo(groupByPhone);
    }
}