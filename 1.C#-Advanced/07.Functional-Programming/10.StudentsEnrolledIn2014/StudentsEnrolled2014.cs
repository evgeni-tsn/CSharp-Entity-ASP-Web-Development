using System;
using System.Linq;
using System.Text.RegularExpressions;
using _01.ClassStudent;
using _03.StudentsByFirstAndLastName;

class StudentsEnrolled2014
{
    //Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).
    static void Main()
    {
        var database = new StudentDirectory();


        string pattern = @"(?<=\d{4})(14)";
        Regex rgx = new Regex(pattern);
        
        var studentsEnrolledIn2014 =
            from student in database.Students
            where rgx.IsMatch(student.FacultyNumber.ToString())
            select student;

        ByFirstAndLastName.PrintStudentInfo(studentsEnrolledIn2014);

    }
}
