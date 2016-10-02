using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CustomLINQExtensionMethods
{
    class CustomLINQExtension
    {
        static void Main()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var filteredCollection = list.WhereNot(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", filteredCollection));

            var students = new List<Student>
            {
                new Student("Pesho",3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 5)
            };

            Console.WriteLine(students.Max(student => student.Grade));
        }
    }
}
