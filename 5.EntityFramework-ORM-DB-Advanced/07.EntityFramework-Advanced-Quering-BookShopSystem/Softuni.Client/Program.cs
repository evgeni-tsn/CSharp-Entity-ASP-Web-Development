namespace Softuni.Client
{
    using System;
    using System.Linq;
    using Softuni.Models.PartialModels;
    using SoftUni.Data;
    using SoftUni.Models;

    class Program
    {
        static void Main()
        {
            SoftuniContext contex = new SoftuniContext();

            //Task 17
            #region //SP
            //CREATE PROCEDURE FindAllProjectForEmployee @firstName varchar(max), @lastName varchar(max)
            //AS
            //BEGIN
            //SELECT proj.[Name], proj.Description, proj.StartDate FROM Projects proj
            //INNER JOIN EmployeesProjects emproj
            //ON emproj.ProjectID = proj.ProjectID
            //INNER JOIN Employees em
            //ON em.EmployeeID = emproj.EmployeeID AND em.FirstName = @firstName AND em.LastName = @lastName
            //END
            #endregion
            //CallAStoreProcedure(contex);

            //Task 18
            //EmployeesMaximumSalaries(contex);
        }

        private static void EmployeesMaximumSalaries(SoftuniContext contex)
        {
            var departmentsMax = contex.Departments.Select(department => new
            {
                department.Name,
                MaxSalary = department.Employees.Max(employee => employee.Salary)
            }).Where(arg => arg.MaxSalary < 30000 | arg.MaxSalary > 70000);

            foreach (var departmentMax in departmentsMax)
            {
                Console.WriteLine($"{departmentMax.Name} - {departmentMax.MaxSalary}");
            }
        }

        private static void CallAStoreProcedure(SoftuniContext contex)
        {
            var projectsInfo = contex.GetProjectsByEmployee("Ruth", "Ellerbrock");
            foreach (ProjectInfo projectInfo in projectsInfo)
            {
                Console.WriteLine($"{projectInfo.Name} - {projectInfo.Description.Substring(0, 20)}... {projectInfo.StartDate}");
            }
        }
    }
}
