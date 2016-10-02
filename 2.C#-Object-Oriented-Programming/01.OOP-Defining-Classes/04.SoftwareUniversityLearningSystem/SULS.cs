using System;
using System.Collections.Generic;
using System.Linq;

/*  Define a class Person and the classes Trainer, Student. There are two types of trainers – Junior and Senior Trainer. 
    There are three types of Students – Graduate, Current and Dropout Student. 
    There are two types of Current Students – Online and Onsite Student. 
    Implement the given structure below. A class down in the hierarchy should implement the fields, 
    properties and methods of the classes above it. 
    (Tip: Use Inheritance to achieve code reusability). 
    The classes should implement the following fields/methods:
    •	Person – fields first name, last name, age
        o	Trainer – method CreateCourse([courseName]) that prints that the course has been created
            	Senior Trainer – method DeleteCourse([courseName]) that prints that the course has been deleted
        o	Student – fields student number, average grade
            	Current Student – field current course
    •	Onsite Student – field number of visits
            	Dropout Student – field dropout reason, method Reapply() that prints all information about the student and the dropout reason
    Write a class SULSTest that tests the implemented class structure. Create a list of objects from each class. 
    Extract only the Current Students, sort them by average grade and print information about each one on the console.
    Tip: Use the LINQ extension methods Where() and OrderBy() with lambda expressions.
*/

namespace _04.SoftwareUniversityLearningSystem
{
    class SULS
    {
        static void Main()
        {
            var persons = new List<Person>()
            {
                new DropoutStudent("Dimitar", "Berbatov", 35, 159, 4.55,"Low scores"),
                new OnsiteStudent("Pesho", "Peshov", 80, 977, 2.01, "C# Basic", 1),
                new OnlineStudent("Ivaylo", "Tokiev", 33, 897, 4.90, "OOP"),
                new GraduateStudent("Ivancho", "Mariikin", 16, 159, 2.55),
                new GraduateStudent("Pesho", "Goshev", 2, 159, 6.00),
                new SeniorTrainer("Svetlin", "Nakov", 50),
                new JuniorTrainer("Koicho", "Koichev", 99),
            };
            var person = new SeniorTrainer("Svetlin", "Nakov", 40);
            Console.WriteLine(person);
            person.CreateCourse("C#");
            person.DeleteCourse("Java");

            persons
                .OfType<DropoutStudent>()
                .OrderByDescending(student => student.AverageGrade)
                .ToList()
                .ForEach(Console.WriteLine);


        }
    }
}
