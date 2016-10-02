using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;

namespace _02.StudentsByGroup
{
    class ByGroup
    {
        //Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
        static void Main()
        {
            StudentDirectory database = new StudentDirectory();
            
            var studentsByGroup = 
                from student in database.Students
                orderby student.FirstName
                group student by student.GroupNumber
                into studentGroup
                where studentGroup.Key == 2
                select studentGroup;
            
            PrintStudentInfoByGroup(studentsByGroup);
        }

        public static void PrintStudentInfoByGroup<T>(IEnumerable<IGrouping<T, Student>> studentsQuery)
        {
            foreach (var group in studentsQuery)
            {
                Console.WriteLine("Group: "+ group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);

                    Console.WriteLine("Age: {0}, Faculty Number: {1} ",student.Age, student.FacultyNumber);
                    Console.WriteLine("Phone: {0}", student.Phone);
                    Console.WriteLine("Email: {0}",student.Email);
                    Console.WriteLine("Grades: {{{0}}}", string.Join(", ", student.Marks));
                    Console.WriteLine();
                }
            }
        }
    }
}
