using System;
using System.Linq;
using _01.ClassStudent;

class ExcellentStudents
{
    //Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
    static void Main()
    {
        var database = new StudentDirectory();

        var groupExcellentStudents =
            from student in database.Students
            where student.Marks.Contains(6)
            select
                new
                {
                    Fullname = string.Join(" ", student.FirstName, student.LastName),
                    Marks = string.Join(" ", student.Marks)
                };

        foreach (var student in groupExcellentStudents)
        {
            Console.WriteLine("Name: {0}, Grades: {{{1}}}", student.Fullname, student.Marks);
        }
    }
}
