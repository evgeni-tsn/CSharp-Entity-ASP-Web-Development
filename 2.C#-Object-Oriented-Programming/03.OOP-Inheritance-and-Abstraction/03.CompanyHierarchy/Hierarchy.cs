using System;
using _03.CompanyHierarchy.Models;

/*Create the following OOP class hierarchy:
    •	Person – general class for anyone, holding id, first name and last name.
        o	Employee – general class for all employees, holding the field salary and department. 
        The department can only be one of the following: Production, Accounting, Sales or Marketing.
            	Manager – holds a set of employees under his command.
            	RegularEmployee
                -	SalesEmployee – holds a set of sales. 
                A sale holds product name, date and price.
                -	Developer – holds a set of projects. 
                A project holds project name, project start date, 
                details and a state (open or closed). 
                A project can be closed through the method CloseProject().
        o	Customer – holds the net purchase amount (total amount of money the customer has spent).

        Extract interfaces for each class. (e.g. IPerson, IEmployee, IManager, etc.) 
        The interfaces should hold their public properties and methods (e.g. IPerson should hold id, first name and last name). Each class should implement its respective interface.

        Define proper constructors. Avoid code duplication through abstraction. 
        Encapsulate all data and validate the input. 
        Throw exceptions where necessary. 
        Override ToString() in all classes to print detailed information about the object.

        Create several employees of type Manager, SalesEmployee and Developer and add them in a single collection. 
        Finally, print them in a for-each loop.
*/

namespace _03.CompanyHierarchy
{
    class Hierarchy
    {
        static void Main()
        {
            SalesEmployee retailer = new SalesEmployee(12, "Firstname", "Lastname", 500, Department.Marketing , new Sale("notebook", 340));

            Employee[] employees =
            {
                retailer,
                new Manager(28882, "Georgi", "Kolev", 5500, Department.Marketing, retailer),
                new Developer(534, "Sava", "Savov", 2300, Department.Production, new Project("Code")),
                new SalesEmployee(342, "Ivan", "Siderov",1200, Department.Accounting,  new Sale("Neshto", 0)),
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
