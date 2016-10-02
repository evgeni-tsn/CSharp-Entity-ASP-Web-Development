using System;
using System.Collections.Generic;
using System.Linq;
using _01.HumanStudentAndWorker.Humans;

namespace _01.HumanStudentAndWorker
{
    /*Define an abstract class Human holding a first name and a last name.
    •	Define a class Student derived from Human that has a field faculty number (5-10 digits / letters).
    •	Define a class Worker derived from Human with fields WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns the payment earned by hour by the worker. 
    •	Define the proper constructors and properties for the classes in your class hierarchy.
    •	Initialize a list of 10 students and sort them by faculty number in ascending order (use a LINQ query or the OrderBy() extension method). Initialize a list of 10 workers and sort them by payment per hour in descending order.
    •	Merge the lists and then sort them by first name and last name.
    */

    class HumanStudentWorker
    {
        static void Main()
        {
            var students = new List<Student>();
            students.Add(new Student("Ivan", "Siderov", "9191982"));
            students.Add(new Student("Georgi", "Kolev", "1919193"));
            students.Add(new Student("Krasi", "Nedev", "9919188"));
            students.Add(new Student("Nanio", "Penkov", "1316516"));
            students.Add(new Student("Sava", "Savov", "13165136"));
            students.Add(new Student("Genadi", "Krasimirov", "13136516"));

            var sortedStudents = students.OrderBy(x => x.FacultyNumber);
            Console.WriteLine("Ordered students by faculty number: ");
            PrintList(sortedStudents);

            var workers = new List<Worker>();
                workers.Add(new Worker("First", "Worker", 23m, 16));
                workers.Add(new Worker("Second", "Worker", 55.99m, 24));
                workers.Add(new Worker("Third", "Worker", 0.1m, 0));
                workers.Add(new Worker("Fourth", "Worker", 100000m, 1));
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            Console.WriteLine("Ordered workers by hourly salary :");
            PrintList(sortedWorkers);

            List<Human> people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);
            var sortedPeople = people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Console.WriteLine("Ordered people (by first and last name):");
            PrintList(sortedPeople);
        }

        private static void PrintList<T>(IOrderedEnumerable<T> list)
        {
            foreach (var human in list)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine();
        }
    }
}
