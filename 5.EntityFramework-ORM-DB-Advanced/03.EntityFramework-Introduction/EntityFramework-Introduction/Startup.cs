using System;
using System.Linq;

namespace EntityFramework_Introduction
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftuniContext();


            //// 3. Employees full information
            //var employees = context.Employees;

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.FirstName + " "
            //                    + employee.LastName + " "
            //                    + employee.MiddleName + " "
            //                    + employee.JobTitle + " "
            //                    + employee.Salary);
            //}

            //// 4. Employees with Salary Over 50 000
            //var employeesNames = context
            //    .Employees
            //    .Where(e => e.Salary > 50000)
            //    .Select(e => e.FirstName);

            //foreach (string employeeName in employeesNames)
            //{
            //    Console.WriteLine(employeeName);
            //}

            //// 5. Employees from Seattle
            //var employeesSeattle = context
            //                .Employees
            //                .Where(e => e.Department.Name == "Research and Development")
            //                .OrderBy(e => e.Salary)
            //                .ThenByDescending(e => e.FirstName);

            //foreach (var employee in employeesSeattle)
            ////{
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} " +
            //                      $"from {employee.Department.Name} - ${employee.Salary:F2}");
            //}

            //// 6. Adding a New Address and Updating Employee

            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //var nakov = context.Employees.First(e => e.LastName == "Nakov");
            //nakov.Address = address;

            //context.SaveChanges();

            //var employeeAddresses = context
            //    .Employees
            //    .OrderByDescending(e => e.Address.AddressID)
            //    .Take(10)
            //    .Select(e => e.Address.AddressText);

            //foreach (var emp in employeeAddresses)
            //{
            //    Console.WriteLine(emp);
            //}

            //// 7. Delete Project by Id

            //var project = context.Projects.Find(2);
            //var employeesDel = context.Employees;
            //foreach (var em in employeesDel)
            //{
            //    em.Projects.Remove(project);
            //}
            //context.SaveChanges();
            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var projects = context
            //    .Projects
            //    .Take(10)
            //    .Select(p => p.Name);

            //foreach (var p in projects)
            //{
            //    Console.WriteLine(p);
            //}

            // 8. Find employees in period
            //var projectsFind = context
            //            .Employees
            //            .Where(e => e.Projects.Count
            //                        (p => p.StartDate.Year >= 2001 
            //                           && p.StartDate.Year <= 2003) > 0)
            //                        .Take(30);

            //foreach (var p in projectsFind)
            //{
            //    Console.WriteLine(p.FirstName + " "
            //                    + p.LastName + " "
            //                    + p.Manager.FirstName);
            //    foreach (var proj in p.Projects)
            //    {
            //        var strsDate = proj.StartDate.ToString(@"M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //        var streDate = proj.EndDate != null ? proj.EndDate.Value.ToString(@"M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "";
            //        Console.WriteLine($"--{proj.Name} {strsDate} {streDate}");
            //    }
            //}

            //            // 9. Аddresses by town name 
            //            var addresses = context
            //                .Addresses
            //                .OrderByDescending(em => em.Employees.Count)
            //                .ThenBy(t => t.Town.Name)
            //                .Take(10);
            //
            //            foreach (var add in addresses)
            //            {
            //                //“addressText, townName – numberOfEmployees employees”   
            //                Console.WriteLine(add.AddressText + ", " + add.Town.Name + " - " + add.Employees.Count + " employees");
            //            }

            //            // 10.	Employee with id 147 sorted by project names 
            //
            //            var employee147 = context
            //                .Employees.Find(147);
            //
            //            var projects = employee147.Projects.OrderBy(p => p.Name);
            //
            //            Console.WriteLine(employee147.FirstName + " " + employee147.LastName + " " + employee147.JobTitle);
            //            foreach (var project in projects)
            //            {
            //                Console.WriteLine(project.Name);
            //            }
            // 11. Departments with more than 5 employees

            //            var departments = context
            //                            .Departments
            //                            .Where(department => department.Employees.Count > 5)
            //                            .OrderBy(department => department.Employees.Count);
            //            foreach (var dep in departments)
            //            {
            //                Console.WriteLine($"{dep.Name} {dep.Employee.FirstName}");
            //                foreach (Employee employee in dep.Employees)
            //                {
            //                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //                }
            //            }
            // 12. Native SQL
            //            context.Addresses.Count();
            //
            //            var timer = new Stopwatch();
            //            timer.Start();
            //            var employeesNames =
            //                context.Employees
            //                    .Where(employee =>
            //                        employee.Projects.Count(project => project.StartDate.Year == 2002) != 0)
            //                    .Select(employee => employee.FirstName).GroupBy(s => s);
            //            foreach (var s in employeesNames)
            //            {
            //
            //            }
            //            timer.Stop();
            //            Console.WriteLine($"Linq: {timer.Elapsed}");
            //            timer.Reset();
            //
            //
            //            timer.Start();
            //            string query = "SELECT em.FirstName FROM Employees em " +
            //                           "JOIN EmployeesProjects emproj " +
            //                           "ON emproj.EmployeeId = em.EmployeeId " +
            //                           "JOIN Projects proj " +
            //                           "ON emproj.ProjectId = proj.ProjectId AND YEAR(proj.StartDate) = 2002 " +
            //                           "GROUP BY em.FirstName";
            //            var result = context.Database.SqlQuery<string>(query);
            //            foreach (var f in result)
            //            {
            //
            //            }
            //            timer.Stop();
            //            Console.WriteLine($"Native: {timer.Elapsed}");
            //            timer.Reset();

            // 15. Find Latest 10 Projects

            //            var latestStartedProjects = context
            //                    .Projects
            //                    .OrderByDescending(project => project.StartDate)
            //                    .Take(10)
            //                    .OrderBy(project => project.Name);
            //            
            //            foreach (var latestStartedProject in latestStartedProjects)
            //            {
            //                var strsDate = latestStartedProject.StartDate.ToString(@"M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //                var streDate = latestStartedProject.EndDate != null ? latestStartedProject.EndDate.Value.ToString(@"M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "";
            //                Console.WriteLine($"{latestStartedProject.Name} {latestStartedProject.Description} {strsDate} {streDate}");
            //            }     

            // 16. Increase Salaries
            //            var employees = context.Employees.Where(employee =>
            //                employee.Department.Name == "Engineering"
            //             || employee.Department.Name == "Tool Design"
            //             || employee.Department.Name == "Marketing"
            //             || employee.Department.Name == "Information Services");
            //            
            //            foreach (var employee in employees)
            //            {
            //                employee.Salary *= 1.12m;
            //                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            //            }
            //            
            //            context.SaveChanges();

            //            // 17. Remove Towns
            //            var townName = Console.ReadLine();
            //            var wantedTown = context.Towns.FirstOrDefault(town => town.Name == townName);
            //            var townAddresses = wantedTown.Addresses.ToArray();
            //            foreach (var townAddress in townAddresses)
            //            {
            //                var employeesAddresses = townAddress.Employees.ToArray();
            //                foreach (var employee in employeesAddresses)
            //                {
            //                    employee.AddressID = null;
            //                }
            //            }
            //            
            //            context.Addresses.RemoveRange(townAddresses);
            //            context.Towns.Remove(wantedTown);
            //            context.SaveChanges();
            //            Console.WriteLine($"{townAddresses.Length} address in {townName} was deleted"); 
            // 18. Find Employees by First Name starting with ‘SA’
//            string pattern = "SA";
//            var employeesByNamePattern = context.Employees
//                .Where(employee => employee.FirstName.StartsWith(pattern));
//
//            foreach (var employeeByPattern in employeesByNamePattern)
//            {
//                Console.WriteLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
//                                  $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
//            }

            // 19. First Letter

        }
    }
}
