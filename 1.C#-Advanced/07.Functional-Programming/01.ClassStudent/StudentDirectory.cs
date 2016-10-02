using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassStudent
{
    public class StudentDirectory
    {
        public List<Student> Students = CreateStudentsDirectory();

        public static List<Student> CreateStudentsDirectory()
        {
            var students = new List<Student>()
            {
                new Student("Ivan", "Siderov", 19, 801231, "+3592897896245", "is@yahoo.com",
                    new List<int>() {4, 2, 6, 5, 3}, 1),
                new Student("Evgeni", "Nikolov",20, 801242, "02891236847", "en@abv.bg",
                    new List<int>() {6, 4, 6, 5, 6}, 2),
                new Student("Krasi", "Nedev", 18, 801253, "0896659873", "kn@gmail.com",
                    new List<int>() {2, 2, 6, 5, 3}, 1),
                new Student("Georgi", "Kolev", 22, 801214, "0895978463", "gk@outlook.com",
                    new List<int>() {4, 2, 3, 5, 3}, 2),
                new Student("Sava", "Savov", 21, 801275, "0892658791", "ss@gmail.com",
                    new List<int>() {2, 2, 3, 5, 3}, 3),
                new Student("Genadi", "Krasimirov", 20, 801214, "0899876541", "gk@abv.bg",
                    new List<int>() {4, 4, 4, 5, 3}, 2)
            };

            return students;
        }
    }
}
