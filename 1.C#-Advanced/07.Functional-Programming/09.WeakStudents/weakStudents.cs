using System;
using System.Collections.Generic;
using System.Linq;
using _01.ClassStudent;
using _03.StudentsByFirstAndLastName;

public static class WeakStudents
{
    //Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.
    static void Main()
    {
        var database = new StudentDirectory();

        var weekStudentsList = database.Students.WeakStudentsList();

        ByFirstAndLastName.PrintStudentInfo(weekStudentsList);
    }

    public static List<Student> WeakStudentsList(this List<Student> students)
    {
        var weakStudent =
        from student in students
        where (student.Marks.Count(x => x == 2) == 2)
        select student;

        return weakStudent.ToList();
    }
}
